@db-11
Feature: UT006 Generate File with global header
	As a developer
	I can generate code with the T4.FileManager using my own custom header

Background: T4 Filemanager
	Given the file manager

Scenario: Generate multiple files with global header
	Given the script "TestGlobalHeader.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.StartHeader();
#>
// -------------------------
// databinding - T4
// -------------------------
<#
fileManager.FinishHeader();
fileManager.CreateNewFile("PersonDtoWithGlobal.g.cs","","",null);	
#>
namespace Test
{
	public class PersonDtoWithGlobal
	{
	}
}
<#
fileManager.CreateNewFile("OrderDtoWithGlobal.g.cs","","",null);	
#>
namespace Test
{
	public class OrderDtoWithGlobal
	{
	}
}
<#
fileManager.Generate();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File           |
		| PersonDtoWithGlobal.g.cs |
		| OrderDtoWithGlobal.g.cs  |
	And all files contains the following content:
		"""
// -------------------------
// databinding - T4
// -------------------------
		"""