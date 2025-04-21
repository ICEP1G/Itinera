using CSharpFunctionalExtensions;
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
    public interface IReviewService
    {
        Task<Result<List<ReviewViewModel>>> GetReviewViewModels(IEnumerable<ReviewDto> reviews, ReviewViewedPage viewedPage);
    }
}
