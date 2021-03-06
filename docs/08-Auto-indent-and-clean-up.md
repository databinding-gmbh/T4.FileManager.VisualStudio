# Auto indent and clean up

## Auto indent

You can set `IsAutoIndentEnabled` for enable Visual Studio process to format your generated files. The process is like opening the generated file, executing command `Edit.FormatDocument (CTRL+K, CTRL+D)`, saving and closing the file. You can change this behaviour by setting the property *IsAutoIndentEnabled* on the file manager:

```
fileManager.IsAutoIndentEnabled = false; // default 
fileManager.IsAutoIndentEnabled = true;
```

**Important: There are 20 attempts per file trying to indent the file. This attempts are like normal user actions, wait until ends!**



##  Auto clean up with ReSharper

You can set `IsAutoCleanUpWithResharperEnabled` for enable ReSharper process to clean up your generated files extendable with your StyleCop settings. The process is like opening the generated file, executing command `ReSharper_SilentCleanupCode (CTRL+E, CTRL+F)`, saving and closing the file. You can change this behaviour by setting the property *IsAutoCleanUpWithResharperEnabled* on the file manager:

```
fileManager.IsAutoCleanUpWithResharperEnabled = false; // default 
fileManager.IsAutoCleanUpWithResharperEnabled = true;
```

**Important: There are 20 attempts per file trying to clean up the file. This attempts are like normal user actions, wait until ends!**

