@db-127
Feature: UT013 Generate File change behaviour
	As a developer
	I can change the behaviour of supress changes to overwrite existing files

Background: T4 File Manager and base script
	Given the file manager
	And the script "TestDelete.tt" with following content for automation
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = new T4FileManager(this.GenerationEnvironment, this.Host);
fileManager.CanOverwriteExistingFile = false;
fileManager.CreateNewFile("TestDelete.g.cs","","TestOverwrite",null);	
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
	Given I run the script for automation
	And the following files are generated:
		| File            | Folder        |
		| TestDelete.g.cs | TestOverwrite |
	And I change the line
		| From                                                                  | To                                                                       |
		| fileManager.CanOverwriteExistingFile = false;                         | fileManager.CanOverwriteExistingFile = true;                             |
		| fileManager.CreateNewFile("TestDelete.g.cs","","TestOverwrite",null); | fileManager.CreateNewFile("TestNoDelete3.g.cs","","TestOverwrite",null); |
		| public class TestDelete                                               | public class NewTestDeleteModel                                          |
	When I run the script for automation
	Then the following files are generated:
		| File               | Folder        |
		| TestNoDelete3.g.cs | TestOverwrite |
	And the following files are cleaned up:
		| File            | Folder        |
		| TestDelete.g.cs | TestOverwrite |