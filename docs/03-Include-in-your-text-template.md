# Include in your text template

Open your text template (*.tt) or create a new one.

### .NET Core, .NET Standard, NET 5

The File Manger will be linked to the NuGet system folder. You can compile your project and then reference it using $(TargetDir) in your template.

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
