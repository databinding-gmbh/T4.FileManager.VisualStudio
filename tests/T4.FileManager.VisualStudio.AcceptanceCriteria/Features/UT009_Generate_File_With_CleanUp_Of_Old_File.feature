﻿@db-8
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

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.CreateNewFile("TestOldFilesCleanUp.g.cs","","",null);	
#>
namespace Test
{
	public class TestOldFilesCleanUp
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
		| TestOldFilesCleanUp.g.cs |

	
Scenario: Generate files with clean up of old files (based on *.info.json)
	Given the script "TestOldFilesCleanUp.tt" modified by following content:
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
fileManager.CreateNewFile("TestOldFilesCleanUpRenamed.g.cs","","",null);	
#>
namespace Test
{
	public class TestOldFilesCleanUpRenamed
	{
	}
}
<#
fileManager.Generate();
#>
		"""
	When I run the script
	Then the following files are cleaned up:
		| File           |
		| TestOldFilesCleanUp.g.cs |
	And the following files are generated:
		| File           |
		| TestOldFilesCleanUpRenamed.g.cs |