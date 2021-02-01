# Start or create file

Put this line into your text template (*.tt) where you want to start a new file:

```
fileManager.CreateNewFile(filename, projectname, subfolders, properties);
```

All the content that follows in your template will go into that file (until you close it with the [Generate()](07-Proceed-to-generate-files.md) method. 



## Parameters

| Parameter   | Type                 | Description                                                  | Exmaple/Value                                                |
| ----------- | -------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| filename    | string               | The name of the file.                                        | "test.cs"<br />required value, must NOT BE *null*            |
| projectname | string               | The name of the project in which the file is created.        | "Test.Business"<br />*null* = project name of current project |
| subfolders  | string               | The path of (sub) folders inside the project.                | Path.Combine("Example", "Tests")<br />*null* = root of project |
| properties  | class FileProperties | Adding visual studio properties as example "CustomTool" or "BuildAction". | var fp= new FileProperties();<br />fp.CustomTool = "ResXFileCodeGenerator" |

#### Properties

Values for **CopyToOutputDirectory**:

```
CopyToOutputDirectory.DoNotCopy
CopyToOutputDirectory.CopyAlways
CopyToOutputDirectory.CopyIfNewer
```

Values for **BuildAction**:

```
BuildAction.None
BuildAction.CSharpCompiler
BuildAction.Content
BuildAction.EmbeddedResource
```

#### *Example* 

```
var settings = new FileProperties();
settings.CustomTool = "";
settings.BuildAction = BuildAction.EmbeddedResource;
settings.CopyToOutputDirectory = CopyToOutputDirectory.DoNotCopy;
```

## *Compatibility to old TemplateFileManager*

```
fileManager.StartNewFile(filename, projectname, subfolders, propertiesFromOldFileManager);
```

**Important: Optional parameters are not implemented in the File Manager because this is no longer possible in T4 since Visual Studio 2017. Clean up optional parameters for the new File Manager.**
