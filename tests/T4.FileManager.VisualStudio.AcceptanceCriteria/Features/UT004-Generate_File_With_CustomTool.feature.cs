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
    [TechTalk.SpecRun.FeatureAttribute("UT004 Generate File with custom tool", new string[] {
            "db-9"}, Description="\tAs a developer\r\n\tI can generate code with the T4.FileManager and definied custom" +
        " tool properties", SourceFile="Features\\UT004-Generate_File_With_CustomTool.feature", SourceLine=1)]
    public partial class UT004GenerateFileWithCustomToolFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "db-9"};
        
#line 1 "UT004-Generate_File_With_CustomTool.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UT004 Generate File with custom tool", "\tAs a developer\r\n\tI can generate code with the T4.FileManager and definied custom" +
                    " tool properties", ProgrammingLanguage.CSharp, new string[] {
                        "db-9"});
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
#line 6
#line hidden
#line 7
 testRunner.Given("the file manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Generate resx-File with custom tool (Dictionary)", Description="\tRemoved since version 2.0.0", SourceLine=8)]
        public virtual void GenerateResx_FileWithCustomToolDictionary()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate resx-File with custom tool (Dictionary)", "\tRemoved since version 2.0.0", tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 9
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
#line 6
this.FeatureBackground();
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Generate resx-File with custom tool (FileProperties)", SourceLine=11)]
        public virtual void GenerateResx_FileWithCustomToolFileProperties()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate resx-File with custom tool (FileProperties)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 12
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
#line 6
this.FeatureBackground();
#line hidden
#line 13
 testRunner.Given("the script \"ProjectTestFP.tt\" with the following content", "<#@ template debug=\"false\" hostspecific=\"true\" language=\"C#\" #>\r\n<#@ assembly nam" +
                        "e=\"System.Core\" #>\r\n<#@ import namespace=\"System.Linq\" #>\r\n<#@ import namespace=" +
                        "\"System.Text\" #>\r\n<#@ import namespace=\"System.Collections.Generic\" #>\r\n<#@ outp" +
                        "ut extension=\".txt\" #>\r\n<#@ include file=\"$(ProjectDir)\\T4.FileManager.VisualStu" +
                        "dio.ttinclude\" #>\r\n<#\r\nvar document = new List<string[]>();\r\ndocument.Add(new st" +
                        "ring[] { \"FirstName\", \"Vorname\", \"Angaben zum Vornamen\"});\r\ndocument.Add(new str" +
                        "ing[] { \"LastName\", \"Nachname\", \"Angaben zum Nachnamen\"});\r\ndocument.Add(new str" +
                        "ing[] { \"Street\", \"Strasse\", \"Angaben zur Strasse\"});\r\n\r\nvar fileManager = Templ" +
                        "ateFileManager.Create(this);\r\n\r\nvar fp = new FileProperties();\r\nfp.CustomTool = " +
                        "\"ResXFileCodeGenerator\";\r\n\r\nfileManager.CreateNewFile(\"ProjectTestFP.resx\", \"\", " +
                        "\"\", fp); // <-- use method of FileProperties only (since Version 2.0.0)\r\n#>\r\n<?x" +
                        "ml version=\"1.0\" encoding=\"utf-8\"?>\r\n<root>\r\n<xsd:schema id=\"root\" xmlns=\"\" xmln" +
                        "s:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com" +
                        ":xml-msdata\">\r\n  <xsd:element name=\"root\" msdata:IsDataSet=\"true\">\r\n    <xsd:com" +
                        "plexType>\r\n      <xsd:choice maxOccurs=\"unbounded\">\r\n        <xsd:element name=\"" +
                        "data\">\r\n          <xsd:complexType>\r\n            <xsd:sequence>\r\n              <" +
                        "xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n" +
                        "              <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata" +
                        ":Ordinal=\"2\" />\r\n            </xsd:sequence>\r\n            <xsd:attribute name=\"n" +
                        "ame\" type=\"xsd:string\" msdata:Ordinal=\"1\" />\r\n            <xsd:attribute name=\"t" +
                        "ype\" type=\"xsd:string\" msdata:Ordinal=\"3\" />\r\n            <xsd:attribute name=\"m" +
                        "imetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />\r\n          </xsd:complexType>\r\n" +
                        "        </xsd:element>\r\n        <xsd:element name=\"resheader\">\r\n          <xsd:c" +
                        "omplexType>\r\n            <xsd:sequence>\r\n              <xsd:element name=\"value\"" +
                        " type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n            </xsd:sequen" +
                        "ce>\r\n            <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />\r" +
                        "\n          </xsd:complexType>\r\n        </xsd:element>\r\n      </xsd:choice>\r\n    " +
                        "</xsd:complexType>\r\n  </xsd:element>\r\n</xsd:schema>\r\n<resheader name=\"resmimetyp" +
                        "e\">\r\n  <value>text/microsoft-resx</value>\r\n</resheader>\r\n<resheader name=\"versio" +
                        "n\">\r\n  <value>1.3</value>\r\n</resheader>\r\n<resheader name=\"reader\">\r\n  <value>Sys" +
                        "tem.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.3500.0, Cult" +
                        "ure=neutral, PublicKeyToken=b77a5c561934e089</value>\r\n</resheader>\r\n<resheader n" +
                        "ame=\"writer\">\r\n  <value>System.Resources.ResXResourceWriter, System.Windows.Form" +
                        "s, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\r" +
                        "\n</resheader>\r\n<# \r\nfor (int idx = 0; idx < document.Count; idx++)\r\n{\r\nvar item " +
                        "= document[idx];\r\n#>\r\n<data name=\"<#= item[0] #>\" xml:space=\"preserve\">\r\n  <valu" +
                        "e><#= item[1] #></value>\r\n  <comment><#= item[2] #></comment>\r\n</data>\t \r\n<#} #>" +
                        "\r\n</root>\r\n<#\r\n\r\n\r\nfileManager.Generate();\r\n#>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 93
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table12.AddRow(new string[] {
                            "ProjectTestFP.resx"});
                table12.AddRow(new string[] {
                            "ProjectTestFP.Designer.cs"});
#line 94
 testRunner.Then("the following files are generated:", ((string)(null)), table12, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table13.AddRow(new string[] {
                            "ProjectTestFP.resx"});
#line 98
 testRunner.And("the custom tool is set to \"ResXFileCodeGenerator\" for the following files:", ((string)(null)), table13, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Generate resx-File with custom tool (StartNewFile FileProperties backward compati" +
            "bility T4.TemplateFileManager)", SourceLine=102)]
        public virtual void GenerateResx_FileWithCustomToolStartNewFileFilePropertiesBackwardCompatibilityT4_TemplateFileManager()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate resx-File with custom tool (StartNewFile FileProperties backward compati" +
                    "bility T4.TemplateFileManager)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 103
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
#line 6
this.FeatureBackground();
#line hidden
#line 104
 testRunner.Given("the script \"TestTFMCustomTool.tt\" with the following content", "<#@ template debug=\"false\" hostspecific=\"true\" language=\"C#\" #>\r\n<#@ assembly nam" +
                        "e=\"System.Core\" #>\r\n<#@ import namespace=\"System.Linq\" #>\r\n<#@ import namespace=" +
                        "\"System.Text\" #>\r\n<#@ import namespace=\"System.Collections.Generic\" #>\r\n<#@ outp" +
                        "ut extension=\".txt\" #>\r\n<#@ include file=\"$(ProjectDir)\\T4.FileManager.VisualStu" +
                        "dio.ttinclude\" #>\r\n<#\r\nvar document = new List<string[]>();\r\ndocument.Add(new st" +
                        "ring[] { \"FirstName\", \"Vorname\", \"Angaben zum Vornamen\"});\r\ndocument.Add(new str" +
                        "ing[] { \"LastName\", \"Nachname\", \"Angaben zum Nachnamen\"});\r\ndocument.Add(new str" +
                        "ing[] { \"Street\", \"Strasse\", \"Angaben zur Strasse\"});\r\n\r\nvar fileManager = Templ" +
                        "ateFileManager.Create(this);\r\n\r\nvar fp = new FileProperties();\r\nfp.CustomTool = " +
                        "\"ResXFileCodeGenerator\";\r\n\r\nfileManager.StartNewFile(\"ProjectTestTFM.resx\", \"\", " +
                        "\"\", fp); //<-- Backward compatibility for TemplateFileManager\r\n#>\r\n<?xml version" +
                        "=\"1.0\" encoding=\"utf-8\"?>\r\n<root>\r\n<xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"htt" +
                        "p://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdat" +
                        "a\">\r\n  <xsd:element name=\"root\" msdata:IsDataSet=\"true\">\r\n    <xsd:complexType>\r" +
                        "\n      <xsd:choice maxOccurs=\"unbounded\">\r\n        <xsd:element name=\"data\">\r\n  " +
                        "        <xsd:complexType>\r\n            <xsd:sequence>\r\n              <xsd:elemen" +
                        "t name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n          " +
                        "    <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"" +
                        "2\" />\r\n            </xsd:sequence>\r\n            <xsd:attribute name=\"name\" type=" +
                        "\"xsd:string\" msdata:Ordinal=\"1\" />\r\n            <xsd:attribute name=\"type\" type=" +
                        "\"xsd:string\" msdata:Ordinal=\"3\" />\r\n            <xsd:attribute name=\"mimetype\" t" +
                        "ype=\"xsd:string\" msdata:Ordinal=\"4\" />\r\n          </xsd:complexType>\r\n        </" +
                        "xsd:element>\r\n        <xsd:element name=\"resheader\">\r\n          <xsd:complexType" +
                        ">\r\n            <xsd:sequence>\r\n              <xsd:element name=\"value\" type=\"xsd" +
                        ":string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n            </xsd:sequence>\r\n     " +
                        "       <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />\r\n         " +
                        " </xsd:complexType>\r\n        </xsd:element>\r\n      </xsd:choice>\r\n    </xsd:comp" +
                        "lexType>\r\n  </xsd:element>\r\n</xsd:schema>\r\n<resheader name=\"resmimetype\">\r\n  <va" +
                        "lue>text/microsoft-resx</value>\r\n</resheader>\r\n<resheader name=\"version\">\r\n  <va" +
                        "lue>1.3</value>\r\n</resheader>\r\n<resheader name=\"reader\">\r\n  <value>System.Resour" +
                        "ces.ResXResourceReader, System.Windows.Forms, Version=2.0.3500.0, Culture=neutra" +
                        "l, PublicKeyToken=b77a5c561934e089</value>\r\n</resheader>\r\n<resheader name=\"write" +
                        "r\">\r\n  <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version" +
                        "=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\r\n</reshead" +
                        "er>\r\n<# \r\nfor (int idx = 0; idx < document.Count; idx++)\r\n{\r\nvar item = document" +
                        "[idx];\r\n#>\r\n<data name=\"<#= item[0] #>\" xml:space=\"preserve\">\r\n  <value><#= item" +
                        "[1] #></value>\r\n  <comment><#= item[2] #></comment>\r\n</data>\t \r\n<#} #>\r\n</root>\r" +
                        "\n<#\r\n\r\n\r\nfileManager.Process();\r\n#>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 184
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table14.AddRow(new string[] {
                            "ProjectTestTFM.resx"});
                table14.AddRow(new string[] {
                            "ProjectTestTFM.Designer.cs"});
#line 185
 testRunner.Then("the following files are generated:", ((string)(null)), table14, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "File"});
                table15.AddRow(new string[] {
                            "ProjectTestTFM.resx"});
#line 189
 testRunner.And("the custom tool is set to \"ResXFileCodeGenerator\" for the following files:", ((string)(null)), table15, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
