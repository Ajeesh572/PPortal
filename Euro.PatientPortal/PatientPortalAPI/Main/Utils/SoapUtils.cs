// <copyright file="SoapUtils.cs" company="IDT">
// Copyright (c) IDT. All rights reserved.
// </copyright>

namespace Euro.CP.Main.Utils
{
    using Euro.Core.Automation.Utilities.JsonManager;
    using Euro.CP.OldPSF;

    /// <summary>
    /// Handles the URL of different Soap Clients according to environment.
    /// </summary>
    public class SoapUtils
    {
        /// <summary>
        /// Gets the PSF client according to Environment from environment.json
        /// </summary>
        /// <param name="apiName">Name of API</param>
        /// <returns>PSF client</returns>
        public static PSF GetPsf(string apiName)
        {
            Api api = EnvironmentManager.GetApiInfo(apiName);
            return new PSF
            {
                Url = api.Url
            };
        }
    }
}
