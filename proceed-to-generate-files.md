# proceed to generate files

At the end generate the files with following code.

```
fileManager.Generate();
```

## Overwrite existing files

There is a variable to define if existing generated files should be overwritten or not.

```
fileManager.CanOverwriteExistingFile = true; // default
fileManager.CanOverwriteExistingFile = false;
```

## *compatibility to old FileManager*

```
fileManager.Process();
```

