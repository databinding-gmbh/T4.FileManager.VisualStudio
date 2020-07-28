# Features

## Get namespace

If you want to get automatically the namespace of your current file, you can use following code for standard C# code namespace.

```
fileManager.GetNamespaceForCSharpCode();
```

**Important: Method can only be used after CreateNewFile(...)/StartNewFile(...)**.

## Auto indent

You can set `IsAutoIndentEnabled` for enable visual studio process to format your generated files. The process is like opening the generated file, executing command `Edit.FormatDocument (CTRL+K, CTRL+D)`, saving and closing the file. Set property on file manager as following.

```
fileManager.IsAutoIndentEnabled = false; // default 
fileManager.IsAutoIndentEnabled = true;
```

**Important: There are 20 attempts per file trying to indent the file. This attempts are like normal user actions, wait until ends!**

##  Auto clean up with resharper

You can set `IsAutoCleanUpWithResharperEnabled` for enable Resharper process to clean up your generated files extendable with your StyleCop settings. The process is like opening the generated file, executing command `ReSharper_SilentCleanupCode (CTRL+E, CTRL+F)`, saving and closing the file. Set property on file manager as following.

```
fileManager.IsAutoCleanUpWithResharperEnabled = false; // default 
fileManager.IsAutoCleanUpWithResharperEnabled = true;
```

**Important: There are 20 attempts per file trying to clean up the file. This attempts are like normal user actions, wait until ends!**
