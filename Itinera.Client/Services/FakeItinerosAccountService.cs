using Itinera.DTOs.Itineros;

namespace Itinera.Client.Services
{
    public class FakeItinerosAccountService : IItinerosAccountService
    {
        private readonly FakeDataService _fakeDataService;

        public FakeItinerosAccountService(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }

        public async Task<ItinerosDto> GetCurrentUserAsync()
        {
            return await Task.FromResult(_fakeDataService.GetItineros("currentUserId", "currentUserId"));
        }
    }
}
