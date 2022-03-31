# Quick start

After you installed T4.FileManager into your project, you can dive right into your T4 template. A more thorough explanation follows in the next pages. 

## Include in your text template

Open your text template (*.tt) or create a new one.

### .NET Core, .NET Standard, NET 5, NET 6

The File Manger will be linked to the NuGet system folder. You can compile your project and then reference it using **$(TargetDir)** in your template.

Add the following code to the top of the file:

```
<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>
```


### .NET Framework 

The File Manager will be copied to the Project root. You can reference it using **$(ProjectDir)** in your template.

Add the following code to the top of the file:

```
<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>
```

## Extend your T4 template

With those 4 steps can you use the T4.FileManager to generate code into different files:

1. Set hostspecific="true" in your template
2. [Include T4.FileManager.VisualStudio.ttinclude in your template](02-Quick-start.md#include-in-your-text-template)
3. [Instantiate T4FileManager](04-Create-instance.md)
4. [Start a new file with the CreateNewFile() method](05-Start-or-create-file.md)
5. [Close the file and generate it with the Generate() method](07-Proceed-to-generate-files.md)


The 4 parts are marked in this T4 template:


``` csharp hl_lines="1 8 13 17 27"
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ output extension=".txt" #>

<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>

<#
var files = new string[] { "PersonDto", "OrderDto" };

var fileManager = T4FileManager.Create(this).EnableAutoIndent();

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
```



The call to *EnableAutoIndent()* is not necessary, but it will nicely format your code.



## The result

If you run the template from above it will create the two files PersonDto.g.cs and OrderDto.g.cs next to your template.



PersonDto.g.cs: 

``` csharp
namespace Test
{
    public class PersonDto
    {
    }
}
```



OrderDto.g.cs:

``` csharp 
namespace Test
{
	public class OrderDto
	{
	}
}
```



## Want to know more?

This is just the basic usage of T4.FileManager. You can find an explanation on all other features in the next pages of this documentation.

