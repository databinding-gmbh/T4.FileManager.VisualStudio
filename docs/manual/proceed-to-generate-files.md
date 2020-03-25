# Proceed to generate files

Finally the files can be generated with the following code:

```
fileManager.Generate();
```

## Overwrite existing files

There is a variable to define if existing generated files should be overwritten or not.

```
fileManager.CanOverwriteExistingFile = true; // default
fileManager.CanOverwriteExistingFile = false;
```

## *Compatibility to old FileManager*

```
fileManager.Process();
```

