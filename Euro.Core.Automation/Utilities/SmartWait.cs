// <copyright file="SmartWait.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Exceptions;

    public static class SmartWait
    {

        /// <summary>
        /// This wait until action Func return true in timeoutInSec period with pollingIntervalInSec.
        /// </summary>
        /// <param name="action">Func for wait until return true result</param>
        /// <param name="timeoutInSec">Timeout in seconds for wait until Func action finished</param>
        /// <param name="pollingIntervalInSec">Polling interval in seconds</param>
        /// <param name="raiseException">Throw exception or not if Func action return false after timeoutInSec time</param>
        /// <returns>Return true if Func action return true in timeoutInSec period</returns>
        public static bool WaitUntil(Func<bool> action, int timeoutInSec = 60, int pollingIntervalInSec = 2, bool raiseException = false)
        {
            var timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalMilliseconds < ConvertSecondsInMillisecond(timeoutInSec))
            {
                if (action())
                {
                    return true;
                }

                Thread.Sleep(ConvertSecondsInMillisecond(pollingIntervalInSec));
            }

            if (raiseException)
            {
                throw new SmartWaitTimeoutException();
            }

            return false;
        }

        private static int ConvertSecondsInMillisecond(int seconds) => seconds * 1000;
    }
}
