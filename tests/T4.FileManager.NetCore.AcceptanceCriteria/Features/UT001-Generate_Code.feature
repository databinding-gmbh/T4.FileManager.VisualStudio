﻿@db-6
Feature: UT001 Generate Code
	As a developer
	I can generate code with the T4.FileManager with each class in its own file

Background: T4 FileManager
	Given the file manager

Scenario: Generate two files
	Given the script "Test.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonDto", "OrderDto" };
var fileManager = T4FileManager.Create(this).EnableLog();

foreach(var itm in files)
{
	fileManager.StartNewFile(itm + ".g.cs", "","");
#>
namespace Test
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
		| File           |
		| PersonDto.g.cs |
		| OrderDto.g.cs  |

Scenario: Generate files uses .txt as default file extension .NET Core needs explicit definition of output extension
	Given the script "TestMissingFileExtension.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>

<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonTxtDto", "OrderTxtDto" };
var fileManager = T4FileManager.Create(this);

foreach(var itm in files)
{
	fileManager.StartNewFile(itm + ".g.cs", "","");
#>
namespace Test
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
		| File              |
		| PersonTxtDto.g.cs |
		| OrderTxtDto.g.cs  |


Scenario: Generate files ignores output extension .cs and uses .txt as default to avoid "error generation output" compile errors
    This scenario does not work in Visual Studio 2019 with .NET Core
    *Consider* to use <#@ output extension=".txt" #> for all your T4 Scripts that you create with T4.FileManager


Scenario: Generate files with DisableTemplateMainOutputFile enabled prevents generation of the t4 main output file (Workaround invalid file extension)
    This scenario does not work in Visual Studio 2019 with .NET Core
    *Workaround:* If you delete the main output file by hand and the generation environment has no content, the file will not be recreated.


Scenario: Format file content based on editor.config with EnableAutoIndent flag
	Given the script "TestAutoIndent.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "FileFormat" };
var fileManager = T4FileManager.Create(this).EnableAutoIndent(); // <=== Enable Format Document

foreach(var itm in files)
{
	fileManager.StartNewFile(itm + ".g.cs", "","");
#>
namespace Test
{
  public partial class <#= itm #>
        {
                      public int Id {get; set;}
                            public string Name {get; set;}
  }
}

<#
}

fileManager.Process();
#>
		"""
	When I run the script
	Then the file "FileFormat.g.cs" has following format:
		"""
		namespace Test
		{
		    public partial class FileFormat
		    {
		        public int Id { get; set; }
		        public string Name { get; set; }
		    }
		}
		"""