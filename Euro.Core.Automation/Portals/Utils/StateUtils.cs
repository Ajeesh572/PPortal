// <copyright file="StateUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Portals.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// This class contains all states with its respective initials
    /// </summary>
    public class StateUtils
    {
        /// <summary>
        /// Creates a dictionary that contains all states with initials
        /// </summary>
        /// <returns> Returned dictionary </returns>
        public static Dictionary<string, string> GetStatesDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "AL", "Alabama" },
                { "AA", "APO - AA " },
                { "AE", "APO - AE" },
                { "AP", "APO - AP" },
                { "AK", "Alaska" },
                { "AZ", "Arizona" },
                { "AR", "Arkansas" },
                { "CA", "California" },
                { "CO", "Colorado" },
                { "CT", "Connecticut" },
                { "DC", "District of Columbia" },
                { "FL", "Florida" },
                { "GA", "Georgia" },
                { "HI", "Hawaii" },
                { "ID", "Idaho" },
                { "IL", "Illinois" },
                { "IN", "Indiana" },
                { "IA", "Iowa" },
                { "KS", "Kansas" },
                { "KY", "Kentucky" },
                { "LA", "Louisiana" },
                { "ME", "Maine" },
                { "MD", "Maryland" },
                { "MA", "Massachusetts" },
                { "MI", "Michigan" },
                { "MN", "Minnesota" },
                { "MS", "Mississippi" },
                { "MO", "Missouri" },
                { "MT", "Montana" },
                { "NE", "Nebraska" },
                { "NV", "Nevada" },
                { "NH", "New Hampshire" },
                { "NJ", "New Jersey" },
                { "NM", "New Mexico" },
                { "NY", "New York" },
                { "NC", "North Carolina" },
                { "OH", "Ohio" },
                { "OK", "Oklahoma" },
                { "OR", "Oregon" },
                { "PA", "Pennsylvania" },
                { "PR", "Puerto Rico" },
                { "RI", "Rhode Island" },
                { "SC", "South Carolina" },
                { "SD", "South Dakota" },
                { "TN", "Tennessee" },
                { "TX", "Texas" },
                { "UT", "Utah" },
                { "VT", "Vermont" },
                { "VA", "Virginia" },
                { "WA", "Washington" },
                { "WV", "West Virginia" },
                { "WI", "Wisconsin" },
                { "WY", "Wyoming" }
            };
        }
    }

}
