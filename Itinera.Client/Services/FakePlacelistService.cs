using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakePlacelistService : IPlacelistService
    {
        public FakePlacelistService()
        {

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
