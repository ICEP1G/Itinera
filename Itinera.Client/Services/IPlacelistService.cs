using CSharpFunctionalExtensions;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public interface IPlacelistService
    {
        Task<Result<List<PlacelistHeaderViewModel>>> GetPlacelistHeaderViewModels(IEnumerable<PlacelistHeaderDto> placelistHeaders);
        Task<Result<PlacelistsPageDto>> GetPlacelistsForPageByItinerosId(string currentItinerosId);
        Task<Result<PlacelistContentDto>> GetPlacelistContentViewModel(string placelistId);
        Task<Result<List<PlaceHeaderViewModel>>> GetPlaceHeaderViewModels(IEnumerable<PlaceHeaderDto> placeHeaders);
        Task UpdatePlacelistRecommandation(string placelistId, string currentItinerosId, bool isRecommended);
        Task UpdatePlacelistFollow(string placelistId, string currentItinerosId, bool isFollowing);
    }
}
