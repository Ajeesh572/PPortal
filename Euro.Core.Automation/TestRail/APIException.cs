// <copyright file="APIException.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.TestRail
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// TestRail API binding for .NET (API v2, available since TestRail 3.0)
    /// Learn more:
    /// http://docs.gurock.com/testrail-api2/start
    /// http://docs.gurock.com/testrail-api2/accessing
    /// Copyright Gurock Software GmbH. See license.md for details.
    /// </summary>
    [Serializable]
    public class APIException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIException"/> class.
        /// </summary>
        public APIException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIException"/> class
        /// with a message.
        /// </summary>
        /// <param name="message">Message sent to APIException</param>
        public APIException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIException"/> class
        /// with a message and expection.
        /// </summary>
        /// <param name="message">Message sent to APIException</param>
        /// <param name="innerException">Inner exception</param>
        public APIException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIException"/> class
        /// with a info and context.
        /// </summary>
        /// <param name="info">Info message</param>
        /// <param name="context">Context message</param>
        protected APIException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
