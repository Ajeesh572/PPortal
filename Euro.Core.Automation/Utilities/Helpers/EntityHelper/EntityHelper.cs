// <copyright file="EntityHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.EntityHelper
{
    using System.Collections.Generic;
    using System.Linq;
    using Euro.Core.Automation.Entities;

    /// <summary>
    /// Class that helps working with entities.
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// Compare entities.
        /// </summary>
        /// <param name="expectedEntity">Expected entity.</param>
        /// <param name="actualEntity">Actual entity.</param>
        /// <param name="skippedFields">List of fields will skip in check.</param>
        /// <param name="isCheckFieldsWithNullValue"> If this parameter false, all fields in expectedEntity which have value null skipped from check.</param>
        /// <returns>Return true if equals false if not.</returns>
        public static bool AreEntitiesEquals(this BaseEntity expectedEntity, BaseEntity actualEntity, List<string> skippedFields = null, bool isCheckFieldsWithNullValue = false)
        {
            var fieldsForCheck = expectedEntity.GetPropertyNames();
            if (!isCheckFieldsWithNullValue)
            {
                fieldsForCheck = fieldsForCheck.Where(name => expectedEntity[name] != null).ToList();
            }

            if (skippedFields != null)
            {
                fieldsForCheck = fieldsForCheck.Where(name => !skippedFields.Contains(name)).ToList();
            }

            return !fieldsForCheck.Any(name => (string)expectedEntity[name] != (string)actualEntity[name]);
        }
    }
}
