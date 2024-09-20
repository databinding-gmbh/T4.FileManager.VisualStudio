@db-8
Feature: UT003 Generate File in other project
	As a developer
	I can generate code with the T4.FileManager with each class in its own file or in different projects

Scenario: Generate files in other .NET project
	Given the file manager	
	And the script "TestInOtherProject.tt" with the following content
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
var fileManager = new T4FileManager(this);

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs","T4.FileManager.VisualStudio.AcceptanceCriteria.ExampleTestProject","");
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
	And I select the target project "T4.FileManager.VisualStudio.AcceptanceCriteria.ExampleTestProject"
	When I run the script
	Then the following files are generated:
		| File           | 
		| PersonDto.g.cs |  
		| OrderDto.g.cs  |