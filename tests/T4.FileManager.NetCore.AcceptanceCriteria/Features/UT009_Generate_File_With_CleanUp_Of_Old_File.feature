@db-8
Feature: UT009 Generate File with cleanup old File
	As a developer
	I can generate code with the T4.FileManager without taking care of old generated files

Background: Previously run automation created files
	Given the file manager
	And the script "TestOldFilesCleanUp.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.StartNewFile("TestOldFilesCleanUp.g.cs","","");	
#>
namespace Test
{
	public class TestOldFilesCleanUp
	{
	}
}
<#
fileManager.Process();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File                     |
		| TestOldFilesCleanUp.g.cs |

Scenario: Generate files with clean up of old files (based on *.info.json)
	Given I change the line
		| From                                                        | To                                                                 |
		| fileManager.StartNewFile("TestOldFilesCleanUp.g.cs","",""); | fileManager.StartNewFile("TestOldFilesCleanUpRenamed.g.cs","",""); |
	When I run the script
	Then the following files are cleaned up:
		| File                     |
		| TestOldFilesCleanUp.g.cs |
	And the following files are generated:
		| File                            |
		| TestOldFilesCleanUpRenamed.g.cs |