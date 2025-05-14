using CSharpFunctionalExtensions;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakeItinerosService : IItinerosService
    {
        private readonly FakeDataService _fakeDataService;
        public FakeItinerosService(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }


        public async Task<Result<ItinerosDto>> GetItinerosById(string targetItinerosId, string currentItinerosId)
        {
            try
            {
                await Task.Delay(500);
                ItinerosDto? itineros = _fakeDataService.GetItineros(targetItinerosId, currentItinerosId);
                if (itineros is null)
                    return Result.Failure<ItinerosDto>("Itineros not found");

                return Result.Success(itineros);
            }
            catch (Exception ex)
            {
                return Result.Failure<ItinerosDto>($"Unexpected error: {ex.Message}");
            }
        }


        public async Task<Result<bool>> UpdateItinerosRecommandation(string targetItinerosId, string currentItinerosId, bool isRecommended)
        {
            await Task.Delay(500);
            return Result.Success(true);
        }

        public async Task<Result<bool>> UpdateItinerosFollow(string targetItinerosId, string currentItinerosId, bool isFollowing)
        {
            await Task.Delay(500);
            return Result.Success(true);
        }

        public async Task<Result<List<ReviewDto>>> GetFollowedItinerosLastReviews(string currentItinerosId)
        {
            try
            {
                await Task.Delay(500);
                List<ReviewDto>? lastReviews = _fakeDataService.GetLastReviewsFromFollowedItineros(currentItinerosId);
                if (lastReviews is null)
                    return Result.Failure<List<ReviewDto>>("Last reviews not found");

                return Result.Success(lastReviews);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<ReviewDto>>($"Unexpected error: {ex.Message}");
            }
        }
    }
}
