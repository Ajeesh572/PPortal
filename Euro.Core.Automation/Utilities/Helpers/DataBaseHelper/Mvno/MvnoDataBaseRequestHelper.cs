// <copyright file="MvnoDataBaseRequestHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.DataBaseHelper.Mvno
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Euro.Core.Automation.Utilities.Logger;

    /// <summary>
    /// Class helps to get data from data base.
    /// </summary>
    public class MvnoDataBaseRequestHelper
    {
        /// <summary>
        /// Gets class from data base for activated/swapped device
        /// </summary>
        /// <param name="query">Query that is used to get value</param>
        /// <param name="columnName">Column name for which to get value</param>
        /// <param name="parameterForQuery">Parameter for query that is used</param>
        /// <returns>Class id for activated/swapped number</returns>
        public static string GetDataFromDbViaPhoneNumber(string query, string columnName, string parameterForQuery = null)
        {
            const int sleepIntervalInMillSeconds = 1000;
            const int waitingIntervalInMilSeconds = 80000;
            var watch = Stopwatch.StartNew();
            var currentTime = watch.ElapsedMilliseconds;
            var howLongToWaitInSeconds = currentTime + waitingIntervalInMilSeconds;
            while (currentTime < howLongToWaitInSeconds)
            {
                if (!DataBaseOperationHelper.IsValuePresentedInDb(DataBaseName.OneApp, query, parameterForQuery))
                {
                    Thread.Sleep(sleepIntervalInMillSeconds);
                    currentTime = watch.ElapsedMilliseconds;
                }
                else
                {
                    return DataBaseOperationHelper.GetColumnValueByColumnName(query, columnName, parameterForQuery);
                }
            }

            var errorMessage = $"The database doesn't return any value for query '{query}' where parameter For Query is '{parameterForQuery}' withing '{waitingIntervalInMilSeconds}' milliseconds!";
            Logging.Error(errorMessage);
            throw new TimeoutException(errorMessage);
        }
    }
}
