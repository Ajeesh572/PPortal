// <copyright file="CreditCard.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.JsonManager
{
    public class CreditCard
    {
        /// <summary>
        /// Gets or sets get/Set Type.
        /// Returns/sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets get/Set Number.
        /// Returns/sets the Number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets get/Set Cvv.
        /// Returns/sets the Cvv.
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Gets or sets get/Set ExpirationMonth.
        /// Returns/sets the ExpirationMonth.
        /// </summary>
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// Gets or sets get/Set ExpirationYear.
        /// Returns/sets the ExpirationYear.
        /// </summary>
        public string ExpirationYear { get; set; }
    }
}
