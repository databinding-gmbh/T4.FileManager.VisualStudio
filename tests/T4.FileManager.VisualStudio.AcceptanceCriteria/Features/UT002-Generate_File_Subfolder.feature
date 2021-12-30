@db-7
Feature: UT002 Generate File in subfolder
	As a developer
	I can generate code with the T4.FileManager with each class in its own file in a subfolder

Background: T4 File Manager
	Given the file manager

Scenario: Generate T4 files in existing subfolder
	Given the script "TestSubfolder.tt" with the following content
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
	fileManager.StartNewFile(itm + ".g.cs","","TestSubfolder");
#>
namespace Test.TestSubFolder
{
	public class <#= itm #>
	{
	}
}
<#
}

fileManager.Process();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File           | Folder        |
		| PersonDto.g.cs | TestSubfolder |
		| OrderDto.g.cs  | TestSubfolder |

Scenario: Change output folder in T4 move generated files to new location
	Given the script "TestSubfolderMoving.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonMDto", "OrderMDto" };
var fileManager = new T4FileManager(this);

foreach(var itm in files)
{
	fileManager.StartNewFile(itm + ".g.cs","","TestSubfolder");
#>
namespace Test.TestSubFolder
{
	public class <#= itm #>
	{
	}
}
<#
}

fileManager.Process();
#>
		"""
	When I run the script
	And I change the line
		| From                                                        | To                                                             |
		| fileManager.StartNewFile(itm + ".g.cs","","TestSubfolder"); | fileManager.StartNewFile(itm + ".g.cs","","TestSubfolderNew"); |
	And I run the script again
	Then the following files are generated:
		| File           | Folder           |
		| PersonMDto.g.cs | TestSubfolderNew |
		| OrderMDto.g.cs  | TestSubfolderNew |
	And the following files no longer exist:
		| File           | Folder        |
		| PersonMDto.g.cs | TestSubfolder |
		| OrderMDto.g.cs  | TestSubfolder |