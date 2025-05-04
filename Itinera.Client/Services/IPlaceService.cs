using CSharpFunctionalExtensions;
using Itinera.Client.Models;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Itinera.Client.Services.FakePlaceService;

namespace Itinera.Client.Services
{
    public interface IPlaceService
    {
        Result<string> GetTodayScheduleStatus(Dictionary<string, string> weekSchedules);
        PlaceScheduleStatus GetPlaceScheduleStatus(string daySchedules, DateTime actualDateTime);
        (bool IsFound, string IconUri) GetCorrectPlaceIconUri(string placePrimaryType);
        List<string> GetCorrectPlaceIconUris(HashSet<string> placePrimaryTypes);
        Dictionary<string, string> GetCorrectPlaceIconUrisAndTypes(HashSet<string> placePrimaryTypes);
        Task<Result<List<PlaceHeaderViewModel>>> GetPlaceHeaderViewModels(IEnumerable<PlaceHeaderDto> placeHeaders);
        Task<Result<PlaceContentDto>> GetPlaceContent(string placeId, string currentItinerosId);
        Task<Result<bool>> UpdatePlaceRecommandation(string placeId, string currentItinerosId, bool isRecommended);
    }
}
