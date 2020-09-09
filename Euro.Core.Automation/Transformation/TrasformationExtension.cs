// <copyright file="TrasformationExtension.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Transformation
{
    using System.Collections.Generic;
    using System.Linq;
    using TechTalk.SpecFlow;

    public static class TrasformationExtension
    {
        private static readonly string KeyForFieldName = "Field";

        /// <summary>
        /// Transform table (execute functions or translate if need) for table with header: |Field | Value |.
        /// </summary>
        /// <param name="table">Table for transform.</param>
        /// <returns>Transformed table</returns>
        public static Table TransformTable(this Table table)
        {
            var transformedTable = new Table(table.Header.ToArray());
            var transform = new Transform();
            foreach (var row in table.Rows)
            {
                var values = new Dictionary<string, string>();
                foreach (var field in row)
                {
                    var fieldValue = field.Key == KeyForFieldName ? field.Value : transform.TransformStringValue(field.Value);
                    values.Add(field.Key, fieldValue);
                }

                transformedTable.AddRow(values);
            }

            return transformedTable;
        }
    }
}
