@db-127
Feature: UT013 Generate File with overwrite
	As a developer
	I can change the behaviour of supress changes to overwrite existing files

Background: T4 File Manager and base script
	Given the file manager
	And the script "TestDelete.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = T4FileManager.Create(this).DisableOverwriteExistingFile();

fileManager.CreateNewFile("TestDelete.g.cs","","TestOverwrite");	
#>
namespace Test
{
	public class TestDelete
	{
		// first run template
	}
}
<#
fileManager.Generate();
#>
		"""

Scenario: Generate files with CanOverwriteExistingFile is set to true, files deleted
	Given I run the script
	And the following files are generated:
		| File            | Folder        |
		| TestDelete.g.cs | TestOverwrite |
	And I change the line
		| From                                                             | To                                                                  |
		| T4FileManager.Create(this).DisableOverwriteExistingFile();       | T4FileManager.Create(this);                                         |
		| fileManager.CreateNewFile("TestDelete.g.cs","","TestOverwrite"); | fileManager.CreateNewFile("TestNoDelete3.g.cs","","TestOverwrite"); |
		| public class TestDelete                                          | public class NewTestDeleteModel                                     |
	When I run the script
	Then the following files are generated:
		| File               | Folder        |
		| TestNoDelete3.g.cs | TestOverwrite |
	And the following files are cleaned up:
		| File            | Folder        |
		| TestDelete.g.cs | TestOverwrite |