@db-1017
Feature: UT016 Log activities
	As a developer
	I can log to the main output file
	so that I can analyze the generation process

Background: T4 Filemanager
	Given the file manager

Scenario: Log activities of generation process
	Given the script "TestWithLogEnabled.tt" with the following content
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
var fileManager = new T4FileManager(this).EnableLog(); // <-- log output to main file TestWithLogEnabled.txt

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "", "TestSubfolder");
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
	When I run the script
	Then the file "TestWithLogEnabled.txt" contains following log fragments
		| Textfragment                       |
		| Log to main output file enabled    |
		| Begin CreateNewFile PersonDto.g.cs |
		| Start DeleteExistingFiles          |
		| 2 files generated                  |

Scenario: Add custom information to log
	Given the script "TestWithCustomLog.tt" with the following content
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
var fileManager = new T4FileManager(this).EnableLog(); // <-- log output to main file TestWithLogEnabled.txt

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "", "TestSubfolder");
#>
namespace Test
{
	public class <#= itm #>
	{
		<# fileManager.Log("My custom log info for {0}", itm); #>
	}
}
<#
}

fileManager.Generate();
#>
		"""
	When I run the script
	Then the file "TestWithCustomLog.txt" contains following log fragments
		| Textfragment                     |
		| My custom log info for OrderDto  |
		| My custom log info for PersonDto |