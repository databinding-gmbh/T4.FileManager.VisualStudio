# Start or create file

```
fileManager.CreateNewFile(filename, projectname, subfolders, properties);
```

The following content is then generated into the file. 

To finish the file there are the following possibilities:

- A new file is simply started with the method above. 
- The content should be generated (see [proceed-to-generate-files](../06-Proceed-to-generate-files.md)).
- It will be completed with the finish method: `fileManager.FinishFile()`.

## Parameters

| Parameter   | Type                       | Description                                                  | Exmaple/Value                                                |
| ----------- | -------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| filename    | string                     | The name of started file.                                    | "test.cs"<br />required value, should NOT BE *null*          |
| projectname | string                     | The name of the project, where should be generate the file.  | "Test.Business"<br />*null* = project name of current project |
| subfolders  | string                     | Subfolder path with starting point from defined project.     | Path.Combine("Example", "Tests")<br />*null* = root of project |
| properties  | Dictionary<string, object> | Adding visual studio properties as example "CustomTool" or "CopyToOutputDirectory". | var settings = new Dictionary<string, object>();<br />settings.Add("CopyToOutputDirectory", 1)<br />*null* = no properties set |

#### Properties

There are some defined values for the **Property**:

```
Property.CopyToOutputDirectory
Property.BuildAction
Property.CustomTool 
Property.CanOverwriteExistingFile
```

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

Values for **CanOverwriteExistingFile**:

```
CanOverwriteExistingFile.Yes
CanOverwriteExistingFile.No
```

#### *Example* 

```
var settings = new Dictionary<string, object>();
settings.Add(Property.CopyToOutputDirectory, CopyToOutputDirectory.CopyAlways);
```

## *Compatibility to old FileManager*

```
fileManager.StartNewFile(filename, projectname, subfolders, propertiesFromOldFileManager);
```

**Important: Optional parameters are not implemented in the File Manager because this is no longer possible in T4 since Visual Studio 2017. Clean up optional parameters for the new File Manager.**
