@db-11
Feature: UT006 Generate File with standard header
	As a developer
	I can generate code with the T4.FileManager using a standard header

Background: T4 Filemanager
	Given the file manager

Scenario: Generate multiple files with standard header
	Given the script "TestGlobalHeader.tt" with the following content
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
fileManager.StartHeader();
#>
// -------------------------
// databinding - T4
// -------------------------
<#
fileManager.FinishHeader();
fileManager.StartNewFile("PersonDtoWithGlobal.g.cs","","");	
#>
namespace Test
{
	public class PersonDtoWithGlobal
	{
	}
}
<#
fileManager.CreateNewFile("OrderDtoWithGlobal.g.cs","","");	
#>
namespace Test
{
	public class OrderDtoWithGlobal
	{
	}
}
<#
fileManager.Process();
#>
		"""
	When I run the script
	Then the file "PersonDtoWithGlobal.g.cs" starts with header:
		"""
// -------------------------
// databinding - T4
// -------------------------
		"""
	And the file "PersonDtoWithGlobal.g.cs" starts with header:
		"""
// -------------------------
// databinding - T4
// -------------------------
		"""


Scenario: Generate multiple files with filename in standard header (SA1633)
	Given the script "TestSA1633Header.tt" with the following content
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
fileManager.StartHeader();
#>
// <copyright file="$filename$" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
<#
fileManager.FinishHeader();
fileManager.StartNewFile("PersonDtoWithSA1633.g.cs","","");	
#>
namespace Test
{
	public class PersonDtoWithHeader
	{
	}
}
<#
fileManager.StartNewFile("OrderDtoWithSA1633.g.cs","","");	
#>
namespace Test
{
	public class OrderDtoWithHeader
	{
	}
}
<#
fileManager.Process();
#>
		"""
	When I run the script
	Then the file "PersonDtoWithSA1633.g.cs" starts with header:
		"""
// <copyright file="PersonDtoWithSA1633.g.cs" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
		"""
	And the file "OrderDtoWithSA1633.g.cs" starts with header:
		"""
// <copyright file="OrderDtoWithSA1633.g.cs" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
		"""