# Quick start

After you installed T4.FileManager into your project, you can dive right into your T4 template. A more thorough explanation follows in the next pages. 



## Extend your T4 template

With those 4 steps can you use the T4.FileManager to generate code into different files:

1. [Include T4.FileManager.VisualStudio.ttinclude in your template](03-Include-in-your-text-template.md)
2. [Instantiate T4FileManager](04-Create-instance.md)
3. [Start a new file with CreateNewFile() method](05-Start-or-create-file.md)
4. [Close the file and generate it with the Generate() method](07-Proceed-to-generate-files.md)



The 4 parts are marked in bold in this T4 template:


``` csharp linenums="1" hl_lines="8 13 20 31"
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
fileManager.IsAutoIndentEnabled = true;



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
```



The call to IsAutoIndentEnabled is not necessary, but it will nicely format your code.



## The result

If you run the template from above it will create the two files PersonDto.g.cs and OrderDto.g.cs next to your template.



PersonDto.g.cs: 

```
namespace Test
{
    public class PersonDto
    {
    }
}
```



OrderDto.g.cs:

```
namespace Test
{
	public class OrderDto
	{
	}
}
```



## Want to know more?

This is just the basic usage of T4.FileManager. You can find an explanation on all other features in the next pages of this documentation.

