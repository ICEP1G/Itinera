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
