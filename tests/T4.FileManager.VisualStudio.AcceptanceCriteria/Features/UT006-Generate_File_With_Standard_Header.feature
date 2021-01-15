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

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.StartHeader();
#>
// -------------------------
// databinding - T4
// -------------------------
<#
fileManager.FinishHeader();
fileManager.CreateNewFile("PersonDtoWithGlobal.g.cs","","",null);	
#>
namespace Test
{
	public class PersonDtoWithGlobal
	{
	}
}
<#
fileManager.CreateNewFile("OrderDtoWithGlobal.g.cs","","",null);	
#>
namespace Test
{
	public class OrderDtoWithGlobal
	{
	}
}
<#
fileManager.Generate();
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

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

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
fileManager.CreateNewFile("PersonDtoWithSA1633.g.cs","","",null);	
#>
namespace Test
{
	public class PersonDtoWithHeader
	{
	}
}
<#
fileManager.CreateNewFile("OrderDtoWithSA1633.g.cs","","",null);	
#>
namespace Test
{
	public class OrderDtoWithHeader
	{
	}
}
<#
fileManager.Generate();
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


Scenario: Generate multiple files with filename in standard header (SA1633 - Backward compatibility T4.TemplateFileManager)
	Given the script "TestSA1633HeaderTFM.tt" with the following content
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
fileManager.StartHeader();
#>
// <copyright file="$filename$" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
<#
fileManager.EndBlock();
fileManager.CreateNewFile("PersonDtoWithSA1633TFM.g.cs","","",null);	
#>
namespace Test
{
	public class PersonDtoWithHeader
	{
	}
}
<#
fileManager.CreateNewFile("OrderDtoWithSA1633TFM.g.cs","","",null);	
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
	Then the file "PersonDtoWithSA1633TFM.g.cs" starts with header:
		"""
// <copyright file="PersonDtoWithSA1633TFM.g.cs" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
		"""
	And the file "OrderDtoWithSA1633TFM.g.cs" starts with header:
		"""
// <copyright file="OrderDtoWithSA1633TFM.g.cs" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
		"""