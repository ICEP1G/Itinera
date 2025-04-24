using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakePlacelistService : IPlacelistService
    {
        private readonly FakeDataService _fakeDataService;
        public FakePlacelistService(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }


        public async Task<Result<PlacelistsPageDto>> GetPlacelistsForPageByItinerosId(string currentItinerosId)
        {
            try
            {
                PlacelistsPageDto? placelistsPage = _fakeDataService.GetPlacelistsByItinerosId(currentItinerosId, true);
                if (placelistsPage is null)
                    return Result.Failure<PlacelistsPageDto>("Placelists not found");

                return Result.Success(placelistsPage);
            }
            catch (Exception ex)
            {
                return Result.Failure<PlacelistsPageDto>($"Unexpected error: {ex.Message}");
            }
        }


        public async Task<Result<List<PlacelistHeaderViewModel>>> GetPlacelistHeaderViewModels(IEnumerable<PlacelistHeaderDto> placelistHeaders)
        {
            try
            {
                List<PlacelistHeaderViewModel> placelistHeaderViewModels = new();
                foreach (PlacelistHeaderDto plHeader in placelistHeaders)
                {
                    PlacelistHeaderViewModel placelistHeaderVm = new(ServiceProviderHelper.GetService<IPlaceService>())
                    {
                        Id = plHeader.PlacelistId,
                        Name = plHeader.Name,
                        Description = plHeader.Description,
                        PlacesPrimaryTypes = plHeader.PlacesPrimaryType,
                        ImageUrl = plHeader.ImageUrl,
                        RecommendationCount = plHeader.RecommendationsCount
                    };
                    placelistHeaderViewModels.Add(placelistHeaderVm);
                }
                return Result.Success(placelistHeaderViewModels);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<PlacelistHeaderViewModel>>(ex.Message);
            }
        }


    }
}
