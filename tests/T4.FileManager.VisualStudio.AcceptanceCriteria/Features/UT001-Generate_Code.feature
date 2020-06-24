Feature: UT001 Generate Code
	As a developer
	I can generate code with t4 in different files

Scenario: Generate two files
	Given the file manager
	And the script "Test.tt" with following content for automation
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
var fileManager = T4FileManager.Create(this);

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "","",null);
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
	When i run the script for automation
	Then following files are generated:
		| File           |
		| PersonDto.g.cs |
		| OrderDto.g.cs  |