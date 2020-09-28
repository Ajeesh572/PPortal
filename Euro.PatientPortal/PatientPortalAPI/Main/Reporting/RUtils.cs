// <copyright file="RUtils.cs" company="IDT">
// Copyright (c) IDT. All rights reserved.
// </copyright>

namespace Euro.CP.Main.Utils
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    #region Public Methods

    /// <summary>
    /// Contains Utility methods.
    /// </summary>
    public static class RUtils
    {

        /// <summary>
        ///  Download folder
        /// </summary>
        public const string DownloadsPath = "..\\Downloads";

        /// <summary>
        /// log file folder
        /// </summary>
        public const string LogPath = "..\\TestResults";

        /// <summary>
        /// Gets or sets log result folder
        /// </summary>
        public static string ResultFolder { get; set; }

        /// <summary>
        /// generate random string 
        /// </summary>
        /// <param name="size">how big of the range in the random string</param>
        /// <returns>a random string</returns>
        public static string GetRandomString(int size)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder value = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                value.Append(chars[random.Next(chars.Length)]);
            }
            return value.ToString();
        }

        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
        #endregion
    }
}
