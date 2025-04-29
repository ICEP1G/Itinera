using CSharpFunctionalExtensions;
using Itinera.Client.Models;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakePlaceService : IPlaceService
    {
        private readonly FakeDataService _fakeDataService;
        public readonly Dictionary<string, string> PlaceIconUriDictionary = new();

        public FakePlaceService(IConfiguration configuration, FakeDataService fakeDataService)
        {
            // Add KeyValues pair to the Dictionary from the configuration file
            var placeIconUris = configuration.GetSection("PlaceIconUris");
            if (placeIconUris is not null)
            {
                foreach (var section in placeIconUris.GetChildren())
                {
                    PlaceIconUriDictionary[section.Key] = section.Value;
                }
            }

            _fakeDataService = fakeDataService;
        }


        /// <summary>
        /// Return a schedule for the actual day
        /// </summary>
        /// <param name="weekSchedules"></param>
        /// <returns></returns>
        public Result<string> GetTodayScheduleStatus(Dictionary<string, string> weekSchedules)
        {
            try
            {
                var actualDayName = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture);
                string? todaySchedule = weekSchedules[actualDayName];
                if (todaySchedule is null)
                    return Result.Failure<string>("Impossible to find the actual day");

                return Result.Success(todaySchedule);

            }
            catch (Exception ex)
            {
                return Result.Failure<string>($"Unexpected error: {ex.Message}");
            }
        }


        /// <summary>
        /// Return a Place opening status based on it's actual opened schedules and the Date and time of the actual day
        /// </summary>
        /// <param name="daySchedules"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public PlaceScheduleStatus GetPlaceScheduleStatus(string daySchedules, DateTime actualDateTime)
        {
            try
            {
                TimeSpan currentTime = actualDateTime.TimeOfDay;
                TimeSpan? nextOpeningTime = null;

                string[] scheduleRanges = daySchedules.Split(',');
                foreach (string range in scheduleRanges)
                {
                    string[] times = range.Split(" – "); // Caution, this is not a "-" but a " – ". It's what Google API send to us

                    if (times.Length != 2)
                        throw new Exception("Schedule range is less or more than 2;");

                    string startTimeStr = times[0].Trim();
                    string endTimeStr = times[1].Trim();

                    if (TimeSpan.TryParse(startTimeStr, out TimeSpan startTime) && TimeSpan.TryParse(endTimeStr, out TimeSpan endTime))
                    {
                        if (currentTime >= startTime && currentTime <= endTime)
                        {
                            if (endTime - currentTime <= TimeSpan.FromHours(1))
                                return PlaceScheduleStatus.CloseSoon;

                            return PlaceScheduleStatus.Open;
                        }
                    }

                    // Check if this is the next opening time
                    if (startTime > currentTime && (nextOpeningTime == null || startTime < nextOpeningTime))
                        nextOpeningTime = startTime;
                }

                // Check if there is a next opening time soon
                if (nextOpeningTime.HasValue && nextOpeningTime.Value - currentTime <= TimeSpan.FromHours(1))
                    return PlaceScheduleStatus.OpenSoon;

                return PlaceScheduleStatus.Closed;
            }
            catch (Exception)
            {
                return PlaceScheduleStatus.Closed;
            }
        }


        public (bool IsFound, string IconUri) GetCorrectPlaceIconUri(string placePrimaryType)
        {
            string? placeIconUri = this.PlaceIconUriDictionary.GetValueOrDefault(placePrimaryType);
            if (placeIconUri is not null)
                return (IsFound: true, IconUri: placeIconUri);
            else
                return (IsFound: false, IconUri: "place_icon.png");
        }

        public List<string> GetCorrectPlaceIconUris(HashSet<string> placePrimaryTypes)
        {
            List<string> placeIconUris = new();
            placeIconUris = this.PlaceIconUriDictionary
                .Where(kvp => placePrimaryTypes.Contains(kvp.Key))
                .Select(kvp => kvp.Value)
                .ToList();

            // Push the generic iconUri at the end of the list
            if (placeIconUris.Contains("place_icon.png"))
            {
                placeIconUris.Remove("place_icon.png");
                placeIconUris.Add("place_icon.png");
            }

            return placeIconUris;
        }

        public Dictionary<string, string> GetCorrectPlaceIconUrisAndTypes(HashSet<string> placePrimaryTypes)
        {
            var results = PlaceIconUriDictionary
                .Where(kvp => placePrimaryTypes.Contains(kvp.Key))
                .Select(kvp => new { kvp.Key, kvp.Value })
                .ToList();

            Dictionary<string, string> typesAndUris = new();
            results.ForEach(kvp => { typesAndUris[kvp.Key] = kvp.Value; });

            // Push the generic iconUri at the end of the list
            KeyValuePair<string, string> genericPlaceUri = new(key: "Place", value:"place_icon.png");
            if (typesAndUris.Contains(genericPlaceUri))
            {
                typesAndUris.Remove(genericPlaceUri.Key);
                typesAndUris.Add(genericPlaceUri.Key, genericPlaceUri.Value);
            }

            return typesAndUris;
        }



        public async Task<Result<List<PlaceHeaderViewModel>>> GetPlaceHeaderViewModels(IEnumerable<PlaceHeaderDto> placeHeaders)
        {
            try
            {
                await Task.Delay(500);
                List<PlaceHeaderViewModel> placeHeaderViewModels = new();
                foreach (PlaceHeaderDto placeHeader in placeHeaders)
                {
                    PlaceHeaderViewModel placeHeaderVm = new(this)
                    {
                        Id = placeHeader.PlaceId,
                        Name = placeHeader.Name,
                        Address = placeHeader.Address,
                        PrimaryType = placeHeader.PlacePrimaryType,
                        PrimaryImageUrl = placeHeader.PlacePrimaryImageUrl,
                        TodaySchedules = placeHeader.TodaySchedules,
                    };
                    placeHeaderViewModels.Add(placeHeaderVm);
                }
                return Result.Success(placeHeaderViewModels);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<PlaceHeaderViewModel>>(ex.Message);
            }
        }

        public async Task<Result<PlaceContentDto>> GetPlaceContent(string placeId, string currentItinerosId)
        {
            try
            {
                await Task.Delay(500);
                PlaceContentDto? placeContent = _fakeDataService.GetPlaceById(placeId, currentItinerosId);
                if (placeContent is null)
                    return Result.Failure<PlaceContentDto>("Place not found");

                return Result.Success(placeContent);
            }
            catch (Exception ex)
            {
                return Result.Failure<PlaceContentDto>($"Unexpected error: {ex.Message}");
            }
        }


        public async Task UpdatePlaceRecommandation(string placeId, string currentItinerosId, bool isRecommended)
        {
            await Task.Delay(500);
        }


    }
}
