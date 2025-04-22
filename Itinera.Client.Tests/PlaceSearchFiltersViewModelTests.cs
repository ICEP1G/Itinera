using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Itinera.Client.Tests
{
    public class PlaceSearchFiltersViewModelTests
    {
        private readonly PlaceSearchFiltersViewModel _sut;

        public PlaceSearchFiltersViewModelTests()
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
                .AddSingleton<FakeDataService>()
                .AddSingleton<IPlaceService, FakePlaceService>()
                .BuildServiceProvider();

            HashSet<string> placeTypeFilters = new() { "Restaurant", "Library", "Place" };


            _sut = new(serviceProvider.GetRequiredService<IPlaceService>(), placeTypeFilters);
        }


        [Fact]
        public void AddPlaceTypeFilter_ShoudAdd_OnePlaceTypeFilter()
        {
            // Arrange
            string placeType = "Cemetery";
            ObservableCollection<PlaceTypeFilterViewModel> expected = new()
            {
                new PlaceTypeFilterViewModel("Restaurant", "restaurant_pinlet.png", false),
                new PlaceTypeFilterViewModel("Library", "library_pinlet.png", false),
                new PlaceTypeFilterViewModel("Place", "place_pinlet.png", false),
                new PlaceTypeFilterViewModel("Cemetery", "cemetery_pinlet.png", false)
            };

            // Act
            _sut.AddPlaceTypeFilter(placeType);

            // Assert
            expected.Should().HaveCount(4);
            expected.Should().ContainSingle(ptf => ptf.PlaceType == "Cemetery");
        }

        [Fact]
        public void AddPlaceTypeFilter_ShoudAdd_ThreeTypeFilters()
        {
            // Arrange
            HashSet<string> placeTypes = new() { "Restaurant", "Library", "Cemetery", "Monument", "Civic" };
            ObservableCollection<PlaceTypeFilterViewModel> expected = new()
            {
                new PlaceTypeFilterViewModel("Restaurant", "restaurant_pinlet.png", false),
                new PlaceTypeFilterViewModel("Library", "library_pinlet.png", false),
                new PlaceTypeFilterViewModel("Place", "place_icon.png", false),
                new PlaceTypeFilterViewModel("Cemetery", "cemetery_pinlet.png", false),
                new PlaceTypeFilterViewModel("Monument", "monument_pinlet.png", false),
                new PlaceTypeFilterViewModel("Civic", "civic_pinlet.png", false),
            };

            // Act
            _sut.AddPlaceTypeFilter(placeTypes);

            // Assert
            expected.Should().HaveCount(6);
            expected.Should().ContainSingle(ptf => ptf.PlaceType == "Cemetery");
            expected.Should().ContainInOrder(expected);
        }



        [Fact]
        public void RemovePlaceTypeFilter_ShoudRemove_OnePlaceTypeFilter()
        {
            // Arrange
            string placeType = "Library";
            ObservableCollection<PlaceTypeFilterViewModel> expected = new()
            {
                new PlaceTypeFilterViewModel("Restaurant", "restaurant_pinlet.png", false),
                new PlaceTypeFilterViewModel("Place", "place_pinlet.png", false),
            };

            // Act
            _sut.RemovePlaceTypeFilter(placeType);

            // Assert
            expected.Should().HaveCount(2);
            expected.Should().NotContain(ptf => ptf.PlaceType == "Library");
        }


        [Fact]
        public void RemovePlaceTypeFilter_ShoudRemove_TwoTypeFilter()
        {
            // Arrange
            HashSet<string> placeTypes = new() { "Restaurant", "Library", "Civic" };
            ObservableCollection<PlaceTypeFilterViewModel> expected = new()
            {
                new PlaceTypeFilterViewModel("Place", "place_pinlet.png", false),
            };

            // Act
            _sut.RemovePlaceTypeFilter(placeTypes);

            // Assert
            expected.Should().HaveCount(1);
            expected.Should().OnlyHaveUniqueItems(ptf => ptf.PlaceType == "Place" && ptf.PlaceIconUri == "place_icon.png");
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void RemovePlaceTypeFilter_ShoudOnlyRemain_OnePlaceTypeFilter(HashSet<string> placeTypesToRemove)
        {
            // Arrange
            ObservableCollection<PlaceTypeFilterViewModel> expected = new()
            {
                new PlaceTypeFilterViewModel("Place", "place_pinlet.png", false),
            };

            // Act
            _sut.RemovePlaceTypeFilter(placeTypesToRemove);

            // Assert
            expected.Should().HaveCount(1);
            expected.Should().OnlyHaveUniqueItems(ptf => ptf.PlaceType == "Place" && ptf.PlaceIconUri == "place_icon.png");
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] { new HashSet<string> { "Restaurant", "Library", } },
            new object[] { new HashSet<string> { "Restaurant", "Library", "Restaurant" } },
            new object[] { new HashSet<string> { "Cemetery", "Library", "Restaurant", "Civic", "Monument" } }
        };
    }
}
