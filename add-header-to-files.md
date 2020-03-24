# add header to files

f you want to add a header to your files, you can set it once and it will be added to all your generated files.

At first, you need to start the header.

```c#
fileManager.StartHeader();
```

Add your header content in your T4.

Complete your header.

```c#
fileManager.FinishHeader();
```

If you want to clear your header in same T4 file, you can use following code.

```c#
fileManager.ClearHeader();
```

## *compatibility to old FileManager*

StartHeader is equivalent to old file manager.

 Instead of FinishHeader use old EndBlock.

```
fileManager.EndBlock();
```

### 