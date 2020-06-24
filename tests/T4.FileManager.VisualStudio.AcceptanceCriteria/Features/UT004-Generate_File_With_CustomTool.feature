Feature: UT004 Generate File with custom tool
	As a developer
	I can generate code with t4 with definied custom tool property

Scenario: Generate files with custom tool
	Given the file manager	
	And the script "TestCustomTool.tt" with following content for automation
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonDto", "OrderDto" };
var fileManager = new T4FileManager(this.GenerationEnvironment, this.Host);

var properties = new Dictionary<string, object>();
properties.Add(Property.CustomTool, (object)"TextTemplatingFileGenerator");

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + "WithCustom.g.cs","","",properties);
#>
namespace Test
{
	public class <#= itm #>WithCustom
	{
	}
}
<#
}

fileManager.Generate();
#>
		"""
	When i run the script for automation
	Then following files are generated:
		| File           |
		| PersonDtoWithCustom.g.cs |
		| OrderDtoWithCustom.g.cs  |
	And custom tool is set to "TextTemplatingFileGenerator" for following files:
		| File           |
		| PersonDtoWithCustom.g.cs |
		| OrderDtoWithCustom.g.cs  |