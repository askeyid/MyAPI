﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("User Feature 01")]
    [NUnit.Framework.CategoryAttribute("user")]
    public partial class UserFeature01Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "user"};
        
#line 1 "UserFeature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "User Feature 01", "\tUpdate user", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update user")]
        public void UpdateUser()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update user", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("Get update user payload \"UpdateUser.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.Given("Send request to update username", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.Then("Check firstname is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And("Check lastname is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update user 2")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("DataSource:SayHello.csv")]
        [NUnit.Framework.TestCaseAttribute("Oleg", "HELLO", null)]
        [NUnit.Framework.TestCaseAttribute("Maria", "HEY", null)]
        [NUnit.Framework.TestCaseAttribute("John", "hello", null)]
        [NUnit.Framework.TestCaseAttribute("Alex", "hey", null)]
        public void UpdateUser2(string name, string phrase, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DataSource:SayHello.csv",
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("name", name);
            argumentsOfScenario.Add("phrase", phrase);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update user 2", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
 testRunner.Given("Get update user payload \"UpdateUser.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
 testRunner.Given("Send request to update username", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.Then("Check firstname is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
 testRunner.And("Check lastname is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User enter creds scenario")]
        [NUnit.Framework.CategoryAttribute("myTag")]
        public void UserEnterCredsScenario()
        {
            string[] tagsOfScenario = new string[] {
                    "myTag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User enter creds scenario", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 23
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "Height In Inches",
                            "Bank Account Balance"});
                table1.AddRow(new string[] {
                            "John Galt",
                            "73",
                            "1234.56"});
                table1.AddRow(new string[] {
                            "John Smith",
                            "72",
                            "1234.57"});
#line 24
 testRunner.When("User enter creds", ((string)(null)), table1, "When ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("when do sth")]
        [NUnit.Framework.CategoryAttribute("myScenario")]
        public void WhenDoSth()
        {
            string[] tagsOfScenario = new string[] {
                    "myScenario"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("when do sth", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
 testRunner.When("Peter does something", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
