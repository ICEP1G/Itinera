using Itinera.Client.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Itinera.Client.Services.PlaceService;

namespace Itinera.Client.Tests
{
    public class PlaceServiceTests
    {
        private readonly PlaceService _sut;
        public PlaceServiceTests()
        {
            var configuration = new Dictionary<string, string>()
            {
                { "PlaceIconUris:Cemetery", "cemetery_pinlet.png" },
                { "PlaceIconUris:Civic", "civic_pinlet.png" },
                { "PlaceIconUris:Restaurant", "restaurant_pinlet.png" },
                { "PlaceIconUris:Library", "library_pinlet.png" },
                { "PlaceIconUris:Monument", "monument_pinlet.png" },
                { "PlaceIconUris:Place", "place_icon.png" },
            };

            IConfigurationRoot inMemoryConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(configuration)
                .Build();

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(inMemoryConfiguration)
                .AddSingleton<PlaceService>()
                .BuildServiceProvider();

            _sut = serviceProvider.GetRequiredService<PlaceService>();
        }


        [Fact]
        public void GetCorrectPlaceIconUri_ShouldReturnTrue()
        {
            // Arrange
            string placePrimaryType = "Restaurant";

            // Act
            bool actual = _sut.GetCorrectPlaceIconUri(placePrimaryType).IsFound;

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void GetCorrectPlaceIconUri_ShouldReturnFalse()
        {
            // Arrange
            string placePrimaryType = "zaphod beeblebrox";

            // Act
            bool actual = _sut.GetCorrectPlaceIconUri(placePrimaryType).IsFound;

            // Assert
            Assert.False(actual);
        }


        [Fact]
        public void GetCorrectPlaceIconUris_ShouldHave_EmptyList()
        {
            // Arrange
            HashSet<string> placePrimaryTypes = new();

            // Act
            List<string> actual = _sut.GetCorrectPlaceIconUris(placePrimaryTypes);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetCorrectPlaceIconUris_ShouldHave_SpecificIcons()
        {
            // Arrange
            HashSet<string> placePrimaryTypes = new()
            {
                "Restaurant",
                "Library",
                "Cemetery"
            };

            // Act
            List<string> actual = _sut.GetCorrectPlaceIconUris(placePrimaryTypes);

            // Assert
            List<string> expected = new()
            {
                "restaurant_pinlet.png",
                "library_pinlet.png",
                "cemetery_pinlet.png"
            };

            Assert.Contains("library_pinlet.png", actual);
            Assert.Contains("restaurant_pinlet.png", actual);
            Assert.Contains("cemetery_pinlet.png", actual);
            Assert.Equal(3, actual.Count);
        }

        [Fact]
        public void GetCorrectPlaceIconUris_ShouldHave_SpecificIconsAndGenericOne()
        {
            // Arrange
            HashSet<string> placePrimaryTypes = new()
            {
                "Restaurant",
                "Library",
                "Cemetery",
                "Place"
            };

            // Act
            List<string> actual = _sut.GetCorrectPlaceIconUris(placePrimaryTypes);

            Assert.Contains("library_pinlet.png", actual);
            Assert.Contains("restaurant_pinlet.png", actual);
            Assert.Contains("cemetery_pinlet.png", actual);
            Assert.Contains("place_icon.png", actual);
            Assert.Equal(4, actual.Count);
        }

        [Fact]
        public void GetCorrectPlaceIconUris_ShouldHave_GenericOneAtTheEnd()
        {
            // Arrange
            HashSet<string> placePrimaryTypes = new()
            {
                "Restaurant",
                "Place",
                "Library",
                "Cemetery"
            };

            // Act
            List<string> actual = _sut.GetCorrectPlaceIconUris(placePrimaryTypes);

            Assert.Equal("place_icon.png", actual.Last());
            Assert.Equal(4, actual.Count);
        }

        [Fact]
        public void GetCorrectPlaceIconUrisAndTypes_ShouldHave_CorrespondingIconsWithTypes()
        {
            // Arrange
            HashSet<string> placePrimaryTypes = new()
            {
                "Restaurant",
                "Place",
                "Library",
                "Cemetery"
            };

            // Act
            Dictionary<string, string> actual = _sut.GetCorrectPlaceIconUrisAndTypes(placePrimaryTypes);

            // Assert
            KeyValuePair<string, string> expectedGeneric = new("Place", "place_icon.png");
            Dictionary<string, string> expected = new()
            {
                { "Restaurant", "restaurant_pinlet.png" },
                { "Library", "library_pinlet.png" },
                { "Cemetery", "cemetery_pinlet.png" },
                { "Place", "place_icon.png" },
            };

            Assert.Equal(expected.Count, actual.Count);
            foreach (var expectedKvp in expected)
            {
                Assert.Contains(actual, kvp => kvp.Key == expectedKvp.Key && kvp.Value == expectedKvp.Value);
            }
        }


        [Theory]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T22:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T17:59:59")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T15:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T10:59:59")]
        [InlineData("19:00 – 22:00", "2025-04-08T22:00:01")]
        [InlineData("19:00 – 22:00", "2025-04-08T17:59:59")]
        [InlineData("Closed", "2025-04-08T22:00:01")]
        public void GetPlaceScheduleStatus_ShouldReturn_Closed(string placeSchedules, string dateTimeStr)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeStr);

            // Act
            PlaceScheduleStatus actual = _sut.GetPlaceScheduleStatus(placeSchedules, dateTime);

            // Assert
            Assert.Equal(PlaceScheduleStatus.Closed, actual);
        }


        [Theory]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T19:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T20:59:59")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T12:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T13:59:59")]
        [InlineData("19:00 – 22:00", "2025-04-08T19:00:01")]
        [InlineData("19:00 – 22:00", "2025-04-08T20:59:59")]
        public void GetPlaceScheduleStatus_ShouldReturn_Open(string placeSchedules, string dateTimeStr)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeStr);

            // Act
            PlaceScheduleStatus actual = _sut.GetPlaceScheduleStatus(placeSchedules, dateTime);

            // Assert
            Assert.Equal(PlaceScheduleStatus.Open, actual);
        }


        [Theory]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T18:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T18:59:59")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T11:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T11:59:59")]
        [InlineData("19:00 – 22:00", "2025-04-08T18:00:01")]
        [InlineData("19:00 – 22:00", "2025-04-08T18:59:59")]
        public void GetPlaceScheduleStatus_ShouldReturn_OpenSoon(string placeSchedules, string dateTimeStr)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeStr);

            // Act
            PlaceScheduleStatus actual = _sut.GetPlaceScheduleStatus(placeSchedules, dateTime);

            // Assert
            Assert.Equal(PlaceScheduleStatus.OpenSoon, actual);
        }


        [Theory]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T21:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T21:59:59")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T14:00:01")]
        [InlineData("12:00 – 15:00, 19:00 – 22:00", "2025-04-08T14:59:59")]
        [InlineData("19:00 – 22:00", "2025-04-08T21:00:01")]
        [InlineData("19:00 – 22:00", "2025-04-08T21:59:59")]
        public void GetPlaceScheduleStatus_ShouldReturn_CloseSoon(string placeSchedules, string dateTimeStr)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeStr);

            // Act
            PlaceScheduleStatus actual = _sut.GetPlaceScheduleStatus(placeSchedules, dateTime);

            // Assert
            Assert.Equal(PlaceScheduleStatus.CloseSoon, actual);
        }
    }
}
