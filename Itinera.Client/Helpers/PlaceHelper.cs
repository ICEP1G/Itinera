using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class PlaceHelper
    {
        public static readonly Dictionary<string, string> PlaceIconUriDictionary = new();

        public enum PlaceScheduleStatus
        {
            Open,
            OpenSoon,
            CloseSoon,
            Closed
        }

        /// <summary>
        /// Return a Place opening status based on it's actual opened schedules and the Date and time of the actual day
        /// </summary>
        /// <param name="daySchedules"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PlaceScheduleStatus GetPlaceScheduleStatus(string daySchedules)
        {
            DateTime actualDate = DateTime.Now;
            TimeSpan currentTime = actualDate.TimeOfDay;
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

    }
}
