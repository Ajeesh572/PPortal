﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Euro.PatientPortal.PatientPortalAPI.Test.APITest.Features.Usercreation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("UserCreationVIRACORBU")]
    public partial class UserCreationVIRACORBUFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UserCreationVIRACORBU.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UserCreationVIRACORBU", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("1 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _1CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("1 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("2 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _2CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("2 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 27
 this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("3 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _3CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 48
 this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("4 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _4CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 69
 this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("5 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _5CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("5 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 90
 this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("6 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _6CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("6 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 111
 this.ScenarioSetup(scenarioInfo);
#line 113
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 114
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("7 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _7CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("7 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 132
 this.ScenarioSetup(scenarioInfo);
#line 134
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 135
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("8 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _8CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("8 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 153
 this.ScenarioSetup(scenarioInfo);
#line 155
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("9 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _9CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("9 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 174
 this.ScenarioSetup(scenarioInfo);
#line 176
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 177
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("10 Create Users and set Password Report first VIRACOR bu")]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "1", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "2", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "3", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "4", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "5", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "6", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "7", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report -286.pdf", "8", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "9", null)]
        [NUnit.Framework.TestCaseAttribute("VIRACOR", "@GenerateRandomEmailWithDomain(dispostable.com)", "Ajeesh kv COVID-19 IgG Test Report - 285.pdf", "10", null)]
        public virtual void _10CreateUsersAndSetPasswordReportFirstVIRACORBu(string bu, string email, string reportname, string numOfReports, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10 Create Users and set Password Report first VIRACOR bu", exampleTags);
#line 195
 this.ScenarioSetup(scenarioInfo);
#line 197
 testRunner.Given(string.Format("I send report \"{0}\" for the user \"User\" with email \"{1}\" for Bu \"{2}\"", reportname, email, bu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 198
 testRunner.When("I Create User \"User\" and note referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 199
 testRunner.And("I set password \"Eurofins@2020\" for created User \"User\" with referenceId \"refId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
 testRunner.And(string.Format("I add \"{0}\" reports for user \"User\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
 testRunner.And(string.Format("I added User creds username \"User\" password \"Eurofins@2020\" and number of reports" +
                        " added \"{0}\"", numOfReports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
