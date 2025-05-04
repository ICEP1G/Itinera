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
        Task<Result<PlacelistContentDto>> GetPlacelistContent(string placelistId, string currentItinerosId);
        Task<Result<bool>> UpdatePlacelistRecommandation(string placelistId, string currentItinerosId, bool isRecommended);
        Task<Result<bool>> UpdatePlacelistFollow(string placelistId, string currentItinerosId, bool isFollowing);
    }
}
