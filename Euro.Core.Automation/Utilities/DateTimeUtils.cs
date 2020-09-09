// <copyright file="DateTimeUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// The class provides some methods to manage dates.
    /// </summary>
    public class DateTimeUtils
    {
        /// <summary>
        /// Parses a string date to a specific format.
        /// </summary>
        /// <param name="date">A date represented as string</param>
        /// <param name="pattern">The parameter which the date will be parsed.</param>
        /// <returns>A date respresented as string that matches the specific pattern.</returns>
        public static string ParseDate(string date, string pattern)
            => date != string.Empty ? Convert.ToDateTime(date).ToString(pattern) : string.Empty;

        /// <summary>
        /// Verifies that dates of the list are in range.
        /// </summary>
        /// <param name="initialDate">The initial date of the range.</param>
        /// <param name="endDate">The end dateof the range.</param>
        /// <param name="dateList">The list of dates.</param>
        /// <returns>True if dates are in range, false otherwise.</returns>
        public static bool AreDatesInRange(DateTime initialDate, DateTime endDate, IList<DateTime> dateList)
        {
            bool value = false;
            foreach (DateTime date in dateList)
            {
                if (date >= initialDate && date <= endDate)
                {
                    value = true;
                }
                else
                {
                    value = false;
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// Gets current date in a specific format.
        /// </summary>
        /// <param name="expectedFormatDate">format date</param>
        /// <returns>returns date in string formatted date</returns>
        public static string GetCurrentDateInExpectedFormat(string expectedFormatDate)
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.ToString(expectedFormatDate);
        }

        /// <summary>
        /// Converts a dateTime object to a specific time zone.
        /// </summary>
        /// <param name="dateTime">DateTime object</param>
        /// <param name="timeZoneValue">Specific Time zone value</param>
        /// <returns>returns converted time in datetime object</returns>
        public static DateTime GetConvertedDateTimeToSpecificTimeZone(DateTime dateTime, string timeZoneValue)
        {
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZoneValue));
        }

        /// <summary>
        /// Adds an amount of minutes to a datetime format object.
        /// </summary>
        /// <param name="dateTime">DateTime object</param>
        /// <param name="minutesToAdd">Quantity of minutes</param>
        /// <returns>returns converted time in datetime object</returns>
        public static DateTime AddMinutesToADatetime(DateTime dateTime, double minutesToAdd)
        {
            DateTime increasedDateTimeWithMinutes = dateTime;
            increasedDateTimeWithMinutes = increasedDateTimeWithMinutes.AddMinutes(minutesToAdd);
            return increasedDateTimeWithMinutes;
        }

        /// <summary>
        /// Compare date with accuracy.
        /// </summary>
        /// <param name="firstDateInStringFormat">First date in string format</param>
        /// <param name="secondDateInStringFormat">Second date in string format</param>
        /// <param name="maxAccuracy">Max accurancy</param>
        /// <returns>returns bool state, true if equals, false if not</returns>
        public static bool CompareDate(string firstDateInStringFormat, string secondDateInStringFormat, TimeSpan maxAccuracy)
        {
            var first = DateTime.Parse(firstDateInStringFormat);
            var second = DateTime.Parse(secondDateInStringFormat);
            var actualAccuracy = first > second ? first - second : second - first;
            return actualAccuracy < maxAccuracy;
        }

        /// <summary>
        /// Reformats a date in the given format to a new date format
        /// </summary>
        /// <param name="dateString">The date string</param>
        /// <param name="fromDateFormat">The original date format</param>
        /// <param name="toDateFormat">The new date format</param>
        /// <returns>a date string with the new date format applied</returns>
        public static string ReformatDate(string dateString, string fromDateFormat, string toDateFormat)
        {
            DateTime dt = DateTime.ParseExact(dateString, fromDateFormat, CultureInfo.InvariantCulture);
            string reformattedDate = dt.ToString(toDateFormat, CultureInfo.InvariantCulture);
            return reformattedDate;
        }
    }
}
