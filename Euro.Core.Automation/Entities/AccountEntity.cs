// <copyright file="AccountEntity.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Entities
{
    /// <summary>
    /// Represents account entity with PhoneNumber and SecurityCode properties.
    /// </summary>>
    public class AccountEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets account phone number.
        /// </summary>>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets account security code.
        /// </summary>>
        public string SecurityCode { get; set; }
    }
}
