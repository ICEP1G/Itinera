using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;

namespace Itinera.Client.Services
{
    public class FakePlacelistService : IPlacelistService
    {
        private readonly FakeDataService _fakeDataService;
        private readonly IPlaceService _placeService;
        public FakePlacelistService(FakeDataService fakeDataService, IPlaceService placeService)
        {
            _fakeDataService = fakeDataService;
            _placeService = placeService;
        }


        public async Task<Result<PlacelistsPageDto>> GetPlacelistsForPageByItinerosId(string currentItinerosId)
        {
            try
            {
                await Task.Delay(500);
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
                await Task.Delay(500);
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


        public async Task<Result<PlacelistContentDto>> GetPlacelistContent(string placelistId, string currentItinerosId)
        {
            try
            {
                await Task.Delay(500);
                PlacelistContentDto? placeListContent = _fakeDataService.GetPlacelistById(placelistId);
                if (placeListContent is null)
                    return Result.Failure<PlacelistContentDto>("Placelist not found");

                return Result.Success(placeListContent);
            }
            catch (Exception ex)
            {
                return Result.Failure<PlacelistContentDto>($"Unexpected error: {ex.Message}");
            }
        }


        public async Task<Result<bool>> UpdatePlacelistRecommandation(string placelistId, string currentItinerosId, bool isRecommended)
        {
            await Task.Delay(500);
            return Result.Success(true);
        }

        public async Task<Result<bool>> UpdatePlacelistFollow(string placelistId, string currentItinerosId, bool isFollowing)
        {
            await Task.Delay(500);
            return Result.Success(true);
        }
    }
}
