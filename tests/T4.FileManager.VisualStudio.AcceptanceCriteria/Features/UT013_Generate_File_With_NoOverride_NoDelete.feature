@db-127
Feature: UT013 Generate files without modifications
	As a developer
	I can generate code with t4 and supress changes if the file exist

Background: T4 File Manager and base script
	Given the file manager
	And the script "TestNoDelete.tt" with following content for automation
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
fileManager.CreateNewFile("TestNoDelete.g.cs","","TestOverwrite",null);	
#>
namespace Test
{
	public class TestNoDelete
	{
		// first run template
	}
}
<#
fileManager.Generate();
#>
		"""

Scenario: Generate files with CanOverwriteExistingFile is set to false, no files deleted
	Given i run the script for automation
	And following files are generated:
		| File              | Folder        |
		| TestNoDelete.g.cs | TestOverwrite |
	And i change the line
		| From                                                                    | To                                                                       |
		| fileManager.CreateNewFile("TestNoDelete.g.cs","","TestOverwrite",null); | fileManager.CreateNewFile("TestNoDelete2.g.cs","","TestOverwrite",null); |
		| public class TestNoDelete                                               | public class TestNoDelete2                                               |
	When i run the script for automation
	Then following files are generated:
		| File               | Folder        |
		| TestNoDelete.g.cs  | TestOverwrite |
		| TestNoDelete2.g.cs | TestOverwrite |

Scenario: No content changes if CanOverwriteExistingFile is set to false
	Given i run the script for automation
	And following files are generated:
		| File              | Folder        |
		| TestNoDelete.g.cs | TestOverwrite |
	And i change the line
		| From                  | To                     |
		| // first run template | // second run template |
	When i run the script for automation
	Then following files are generated:
		| File              | Contains              | Folder        |
		| TestNoDelete.g.cs | // first run template | TestOverwrite |