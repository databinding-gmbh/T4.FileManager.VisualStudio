@db-6
Feature: UT001 Generate Code
	As a developer
	I can generate code with the T4.FileManager with each class in its own file

Scenario: Generate two files
	Given the file manager
	And the script "Test.tt" with the following content
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
var fileManager = T4FileManager.Create(this);

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "","",null);
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
	Then the following files are generated:
		| File           |
		| PersonDto.g.cs |
		| OrderDto.g.cs  |


Scenario: Generate files uses .txt as default file extension when no output extension directive is set
	Given the file manager
	And the script "TestMissingFileExtension.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonTxtDto", "OrderTxtDto" };
var fileManager = T4FileManager.Create(this);

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "","",null);
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
	Then the following files are generated:
		| File                         |
		| PersonTxtDto.g.cs            |
		| OrderTxtDto.g.cs             |
		| TestMissingFileExtension.txt |


Scenario: Generate files ignores output extension .cs and uses .txt as default to avoid "error generation output" compile errors
	Given the file manager
	And the script "TestCsExtension.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".cs" #> <# /* **** <====== is ignored **** */ #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonCsDto", "OrderCsDto" };
var fileManager = T4FileManager.Create(this);

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "","",null);
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
	Then the following files are generated:
		| File                |
		| PersonCsDto.g.cs    |
		| OrderCsDto.g.cs     |
		| TestCsExtension.txt |


Scenario: Generate files with DisableTemplateMainOutputFile enabled prevents generation of the t4 main output file (Workaround invalid file extension)
	Given the file manager
	And the script "TestInvalidFileExtension.tt" with the following content
		"""
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonIvDto", "OrderIvDto" };
var fileManager = T4FileManager.Create(this).DisableTemplateMainOutputFile(); // <=== prevent main output file

foreach(var itm in files)
{
	fileManager.CreateNewFile(itm + ".g.cs", "","",null);
#>
namespace Test
{
	public partial class <#= itm #>
	{
	}
}
<#
}

fileManager.Generate();
#>
		"""
	When I run the script
	Then the following files are generated:
		| File             |
		| PersonIvDto.g.cs |
		| OrderIvDto.g.cs  |
	But the following files are not generated:
		| File                         |
		| TestInvalidFileExtension.txt |