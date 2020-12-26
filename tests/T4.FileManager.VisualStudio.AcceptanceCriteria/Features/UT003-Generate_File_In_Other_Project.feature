@db-8
Feature: UT003 Generate File in other project
	As a developer
	I can generate code with t4 in different files and in different project

Scenario: Generate files in other .NET project
	Given the file manager	
	And the script "TestInOtherProject.tt" with following content for automation
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

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs","T4.FileManager.VisualStudio.AcceptanceCriteria.ExampleTestProject","",null);
#>
namespace Test
{
	public class <#= itm #>
	{
	}
}
<#
}

fileManager.Generate();
#>
		"""
	And for target project "T4.FileManager.VisualStudio.AcceptanceCriteria.ExampleTestProject" to generate files
	When i run the script for automation
	Then following files are generated:
		| File           |
		| PersonDto.g.cs |
		| OrderDto.g.cs  |