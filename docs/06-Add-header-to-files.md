# Add header to files 

You can specify a header that is written to your files. Everything that is between *StartHeader()* and *FinishHeader()* will go to the top of your file:

```csharp hl_lines="1 7"
fileManager.StartHeader();
#>
// -------------------------
// databinding - T4
// -------------------------
<#
fileManager.FinishHeader();
fileManager.CreateNewFile("PersonDtoWithGlobal.g.cs","","",null);
```



The generated files all get the same header:

```csharp
// -------------------------
// databinding - T4
// -------------------------
namespace Test
{
	public class PersonDtoWithGlobal
	{
	}
}
```



## Add filename to header

You can access the name of the generated file with the **$filename$** template:

``` csharp hl_lines="4"
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
```



In the generated file $filename$ is replaced with the name of the file:

```c#
// <copyright file="OrderDtoWithSA1633.g.cs" company="databinding.gmbh">
//     databinding.gmbh - All rights reserved.
// </copyright>
// <author>Mr. T4</author>
namespace Test
{
	public class OrderDtoWithHeader
	{
	}
}
```






## Clear Header

You can clear a defined header at any time with this method:

```
fileManager.ClearHeader();
```



## *Compatibility to old FileManager*

StartHeader is equivalent to old file manager.

Instead of FinishHeader use old EndBlock.

```
fileManager.EndBlock();
```

