# Proceed to generate files

Finally, the files can be generated with the following code:

```
fileManager.Generate();
```

## Overwrite existing files

By default T4.FileManager only overwrites files it generated before. If you want to prevent that from happening, you can set the *CanOverwriteExistingFile* property to false:

```
fileManager.CanOverwriteExistingFile = true; // default
fileManager.CanOverwriteExistingFile = false;
```

## *Compatibility to old FileManager*

```
fileManager.Process();
```

