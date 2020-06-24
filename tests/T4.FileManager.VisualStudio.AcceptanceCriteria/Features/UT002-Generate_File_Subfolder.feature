Feature: UT002 Generate File in subfolder
	As a developer
	I can generate T4 files in subfolders

Background: T4 File Manager
	Given the file manager
	And the script "TestSubfolder.tt" with following content for automation
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
	fileManager.CreateNewFile(itm + ".g.cs","","TestSubfolder",null);
#>
namespace Test.TestSubFolder
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

Scenario: Generate T4 files in existing subfolder
	When i run the script for automation
	Then following files are generated:
		| File           | Folder        |
		| PersonDto.g.cs | TestSubfolder |
		| OrderDto.g.cs  | TestSubfolder |

Scenario: Change output folder in T4 move generated files to new location
	And i run the script for automation
	And i change the line
	 | From                                                              | To                                                                   |
	 | fileManager.CreateNewFile(itm + ".g.cs","","TestSubfolder",null); | fileManager.CreateNewFile(itm + ".g.cs","","TestSubfolderNew",null); |
	When i run the script for automation again
	Then following files are generated:
		| File           | Folder           |
		| PersonDto.g.cs | TestSubfolderNew |
		| OrderDto.g.cs  | TestSubfolderNew |
	And the following files no longer exist:
		| File           | Folder        |
		| PersonDto.g.cs | TestSubfolder |
		| OrderDto.g.cs  | TestSubfolder |