using Itinera.DTOs.Itineros;

namespace Itinera.Client.Services
{
    public interface IItinerosAccountService
    {
        Task<ItinerosDto> GetCurrentUserAsync();
    }
}
