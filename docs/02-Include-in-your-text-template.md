# Include in your text template

Create an empty text template file (*.tt). 

### .NET Core, .NET Standard, NET 5

The File Manger will be linked to the nuget system folder. You can compile your project and then reference it using $(TargetDir) in your template.

Add the following code to the top of the file:

```
<#@ include file="$(TargetDir)\T4.FileManager.VisualStudio.ttinclude" #>
```


### .NET Framework

The File Manager will be copied to the Project root. You can reference it using $(ProjectDir) in your template.

Add the following code to the top of the file:

```
<#@ include file="$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude" #>
```
