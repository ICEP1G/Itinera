using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakeReviewService : IReviewService
    {
        public FakeReviewService()
        {
            
        }


        public async Task<Result<List<ReviewViewModel>>> GetReviewViewModels(IEnumerable<ReviewDto> reviews, ReviewViewedPage viewedPage)
        {
            try
            {
                await Task.Delay(1000);
                List<ReviewViewModel> reviewViewModels = new();
                int index = 1;
                foreach (ReviewDto review in reviews)
                {
                    ReviewViewModel reviewVm = new(ServiceProviderHelper.GetService<IPlaceService>())
                    {
                        ReviewId = review.ReviewId,
                        Message = review.Message,
                        ImageUrl = review.ImageUrl,
                        LastModificationDate = review.LastModificationDate,
                        ItinerosId = review.ItinerosId,
                        ItinerosFirstName = review.ItinerosFirstName,
                        ItinerosCity = review.ItinerosCity,
                        ItinerosProfilPictureUrl = review.ItinerosProfilPictureUrl,
                        PlaceId = review.PlaceId,
                        PlaceName = review.PlaceName,
                        PlaceCity = review.PlaceCity,
                        PlaceFirstPictureUrl = review.PlaceFirstPictureUrl,
                        PlaceType = review.PlaceType,
                    };

                    if (index % 2 == 0)
                        reviewVm.IsEven = true;

                    if (viewedPage == ReviewViewedPage.ItinerosPage)
                        reviewVm.IsViewedFromItinerosPage = true;

                    if (viewedPage == ReviewViewedPage.PlacePage)
                        reviewVm.IsViewedFromPlacePage = true;

                    reviewViewModels.Add(reviewVm);
                    index++;
                }
                return Result.Success(reviewViewModels);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<ReviewViewModel>>(ex.Message);
            }
        }


    }
}
