﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.6.0.0
//      SpecFlow Generator Version:3.6.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.6.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("UT009 Generate File with cleanup old File", new string[] {
            "db-8"}, Description="\tAs a developer\r\n\tI can generate code with the T4.FileManager without taking care" +
        " of old generated files", SourceFile="Features\\UT009_Generate_File_With_CleanUp_Of_Old_File.feature", SourceLine=1)]
    public partial class UT009GenerateFileWithCleanupOldFileFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "db-8"};
        
#line 1 "UT009_Generate_File_With_CleanUp_Of_Old_File.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UT009 Generate File with cleanup old File", "\tAs a developer\r\n\tI can generate code with the T4.FileManager without taking care" +
                    " of old generated files", ProgrammingLanguage.CSharp, new string[] {
                        "db-8"});
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
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
#line 8
 testRunner.Given("the file manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.And("the script \"TestOldFilesCleanUp.tt\" with the following content", @"<#@ template debug=""false"" hostspecific=""true"" language=""C#"" #>
<#@ assembly name=""System.Core"" #>
<#@ import namespace=""System.Linq"" #>
<#@ import namespace=""System.Text"" #>
<#@ import namespace=""System.Collections.Generic"" #>
<#@ output extension="".txt"" #>

<#@ include file=""$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude"" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.CreateNewFile(""TestOldFilesCleanUp.g.cs"","""","""");	
#>
namespace Test
{
public class TestOldFilesCleanUp
{
}
}
<#
fileManager.Generate();
#>", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "File"});
            table16.AddRow(new string[] {
                        "TestOldFilesCleanUp.g.cs"});
#line 35
 testRunner.Then("the following files are generated:", ((string)(null)), table16, "Then ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Generate files with clean up of old files (based on *.info.json)", SourceLine=39)]
        public virtual void GenerateFilesWithCleanUpOfOldFilesBasedOn_Info_Json()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate files with clean up of old files (based on *.info.json)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 40
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
this.FeatureBackground();
#line hidden
#line 41
 testRunner.Given("the script \"TestOldFilesCleanUp.tt\" modified by following content:", @"<#@ template debug=""false"" hostspecific=""true"" language=""C#"" #>
<#@ assembly name=""System.Core"" #>
<#@ import namespace=""System.Linq"" #>
<#@ import namespace=""System.Text"" #>
<#@ import namespace=""System.Collections.Generic"" #>
<#@ output extension="".txt"" #>

<#@ include file=""$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude"" #>

<#
var fileManager = new T4FileManager(this);
fileManager.CreateNewFile(""TestOldFilesCleanUpRenamed.g.cs"","""","""");	
#>
namespace Test
{
public class TestOldFilesCleanUpRenamed
{
}
}
<#
fileManager.Generate();
#>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 66
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table17.AddRow(new string[] {
                            "TestOldFilesCleanUp.g.cs"});
#line 67
 testRunner.Then("the following files are cleaned up:", ((string)(null)), table17, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table18.AddRow(new string[] {
                            "TestOldFilesCleanUpRenamed.g.cs"});
#line 70
 testRunner.And("the following files are generated:", ((string)(null)), table18, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
