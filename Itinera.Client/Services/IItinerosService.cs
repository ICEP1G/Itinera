using CSharpFunctionalExtensions;
using Itinera.DTOs;
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
        Task<Result<bool>> UpdateItinerosRecommandation(string targetItinerosId, string currentItinerosId, bool isRecommended);
        Task<Result<bool>> UpdateItinerosFollow(string targetItinerosId, string currentItinerosId, bool isFollowing);
        Task<Result<List<ReviewDto>>> GetFollowedItinerosLastReviews(string currentItinerosId);
    }
}
