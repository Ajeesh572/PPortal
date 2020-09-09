// <copyright file="TestRailCaseIdAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.TestRail.Attribute
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;

    /// <summary>
    /// Attribute to set TestRail Case IDs to a Test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestRailCaseIdAttribute : PropertyAttribute, ITestAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRailCaseIdAttribute"/> class.
        /// Default constructor
        /// </summary>
        /// <param name="testRailCaseId">Test Rail Case ID</param>
        public TestRailCaseIdAttribute(int testRailCaseId)
        {
            TestRailCaseId = testRailCaseId;
        }

        /// <summary>
        /// Test Rail Case ID
        /// </summary>
        public int TestRailCaseId { get; set; }

        public void BeforeTest(ITest test)
        {
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("TestRailId", TestRailCaseId);
        }

        public void AfterTest(ITest test)
        {
        }

        public ActionTargets Targets { get; } = ActionTargets.Test;
    }
}
