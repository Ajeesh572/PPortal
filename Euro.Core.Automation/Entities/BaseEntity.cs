// <copyright file="BaseEntity.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseEntity
    {
        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
            set { GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public List<string> GetPropertyNames() => GetType().GetProperties().Select(property => property.Name)
            .Where(name => name != "Item").ToList();

        public override string ToString()
        {
            var info = new StringBuilder("{");
            GetPropertyNames().ForEach(name => info.Append($"{name}:'{this[name]}',"));
            return info.Append("}").ToString();
        }
    }
}
