﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.5.0.0
//      SpecFlow Generator Version:3.5.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("UT006 Generate File with global header", new string[] {
            "db-11"}, Description="\tAs a developer\r\n\tI can generate code with the T4.FileManager using my own custom" +
        " header", SourceFile="Features\\UT006-Generate_File_With_Global_Header.feature", SourceLine=1)]
    public partial class UT006GenerateFileWithGlobalHeaderFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "db-11"};
        
#line 1 "UT006-Generate_File_With_Global_Header.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UT006 Generate File with global header", "\tAs a developer\r\n\tI can generate code with the T4.FileManager using my own custom" +
                    " header", ProgrammingLanguage.CSharp, new string[] {
                        "db-11"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Generate multiple files with global header", SourceLine=5)]
        public virtual void GenerateMultipleFilesWithGlobalHeader()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate multiple files with global header", null, tagsOfScenario, argumentsOfScenario);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("the file manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.And("the script \"TestGlobalHeader.tt\" with the following content", @"<#@ template debug=""false"" hostspecific=""true"" language=""C#"" #>
<#@ assembly name=""System.Core"" #>
<#@ import namespace=""System.Linq"" #>
<#@ import namespace=""System.Text"" #>
<#@ import namespace=""System.Collections.Generic"" #>
<#@ output extension="".txt"" #>

<#@ include file=""$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude"" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.StartHeader();
#>
// -------------------------
// databinding - T4
// -------------------------
<#
fileManager.FinishHeader();
fileManager.CreateNewFile(""PersonDtoWithGlobal.g.cs"","""","""",null);	
#>
namespace Test
{
public class PersonDtoWithGlobal
{
}
}
<#
fileManager.CreateNewFile(""OrderDtoWithGlobal.g.cs"","""","""",null);	
#>
namespace Test
{
public class OrderDtoWithGlobal
{
}
}
<#
fileManager.Generate();
#>", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table13.AddRow(new string[] {
                            "PersonDtoWithGlobal.g.cs"});
                table13.AddRow(new string[] {
                            "OrderDtoWithGlobal.g.cs"});
#line 50
 testRunner.Then("the following files are generated:", ((string)(null)), table13, "Then ");
#line hidden
#line 54
 testRunner.And("all files contains the following content:", "// -------------------------\r\n// databinding - T4\r\n// -------------------------", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
