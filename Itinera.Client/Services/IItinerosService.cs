using CSharpFunctionalExtensions;
using Itinera.DTOs.Itineros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public interface IItinerosService
    {
        Task<Result<ItinerosDto>> GetItinerosById(string targetItinerosId, string currentItinerosId);
        Task UpdateItinerosRecommandation(string targetItinerosId, string currentItinerosId, bool isRecommended);
        Task UpdateItinerosFollow(string targetItinerosId, string currentItinerosId, bool isFollowing);
    }
}
