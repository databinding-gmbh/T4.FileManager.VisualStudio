@db-9
Feature: UT004 Generate File with custom tool
	As a developer
	I can generate code with the T4.FileManager and definied custom tool properties

Background: T4 FileManager
	Given the file manager

Scenario: Generate resx-File with custom tool (Dictionary)
	Given the script "ProjectTestDict.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>
<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>
<#
var document = new List<string[]>();
document.Add(new string[] { "FirstName", "Vorname", "Angaben zum Vornamen"});
document.Add(new string[] { "LastName", "Nachname", "Angaben zum Nachnamen"});
document.Add(new string[] { "Street", "Strasse", "Angaben zur Strasse"});

var fileManager = TemplateFileManager.Create(this);

var properties = new Dictionary<string, object>();
properties.Add(Property.CustomTool, (object)"ResXFileCodeGenerator");

fileManager.CreateNewFile("ProjectTest.resx", "", "", properties);
#>
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>1.3</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
<# 
for (int idx = 0; idx < document.Count; idx++)
{
	var item = document[idx];
#>
	<data name="<#= item[0] #>" xml:space="preserve">
    <value><#= item[1] #></value>
    <comment><#= item[2] #></comment>
  </data>	 
<#} #>
</root>
<#


fileManager.Generate();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File                    |
		| ProjectTest.resx        |
		| ProjectTest.Designer.cs |
	And the custom tool is set to "ResXFileCodeGenerator" for the following files:
		| File             |
		| ProjectTest.resx |

Scenario: Generate resx-File with custom tool (FileProperties)
	Given the script "ProjectTestFP.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>
<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>
<#
var document = new List<string[]>();
document.Add(new string[] { "FirstName", "Vorname", "Angaben zum Vornamen"});
document.Add(new string[] { "LastName", "Nachname", "Angaben zum Nachnamen"});
document.Add(new string[] { "Street", "Strasse", "Angaben zur Strasse"});

var fileManager = TemplateFileManager.Create(this);

var fp = new FileProperties();
fp.CustomTool = "ResXFileCodeGenerator";

fileManager.CreateNewFile("ProjectTestFP.resx", "", "", fp.ToDictionary()); // <-- use method of FileProperties
#>
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>1.3</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
<# 
for (int idx = 0; idx < document.Count; idx++)
{
	var item = document[idx];
#>
	<data name="<#= item[0] #>" xml:space="preserve">
    <value><#= item[1] #></value>
    <comment><#= item[2] #></comment>
  </data>	 
<#} #>
</root>
<#


fileManager.Generate();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File                      |
		| ProjectTestFP.resx        |
		| ProjectTestFP.Designer.cs |
	And the custom tool is set to "ResXFileCodeGenerator" for the following files:
		| File               |
		| ProjectTestFP.resx |


Scenario: Generate resx-File with custom tool (StartNewFile FileProperties backward compatibility T4.TemplateFileManager)
	Given the script "TestTFMCustomTool.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>
<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>
<#
var document = new List<string[]>();
document.Add(new string[] { "FirstName", "Vorname", "Angaben zum Vornamen"});
document.Add(new string[] { "LastName", "Nachname", "Angaben zum Nachnamen"});
document.Add(new string[] { "Street", "Strasse", "Angaben zur Strasse"});

var fileManager = TemplateFileManager.Create(this);

var fp = new FileProperties();
fp.CustomTool = "ResXFileCodeGenerator";

fileManager.StartNewFile("ProjectTestTFM.resx", "", "", fp); //<-- Backward compatibility for TemplateFileManager
#>
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>1.3</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.3500.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
<# 
for (int idx = 0; idx < document.Count; idx++)
{
	var item = document[idx];
#>
	<data name="<#= item[0] #>" xml:space="preserve">
    <value><#= item[1] #></value>
    <comment><#= item[2] #></comment>
  </data>	 
<#} #>
</root>
<#


fileManager.Process();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File                       |
		| ProjectTestTFM.resx        |
		| ProjectTestTFM.Designer.cs |
	And the custom tool is set to "ResXFileCodeGenerator" for the following files:
		| File                |
		| ProjectTestTFM.resx |