// <copyright file="LoginEntity.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Entities
{
    public class LoginEntity: BaseEntity
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
