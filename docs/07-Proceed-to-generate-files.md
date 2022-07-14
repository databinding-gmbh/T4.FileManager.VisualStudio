# Proceed to generate files

Finally, the files can be generated with the following code:

```
fileManager.Process();
```

## Overwrite existing files

By default T4.FileManager only overwrites files it generated before. If you want to prevent that from happening, you can set the *CanOverwriteExistingFile* property to false:

```
fileManager.CanOverwriteExistingFile = true; // default
fileManager.CanOverwriteExistingFile = false;
```

## Set encoding for generated files

By default file encode is UTF-8. If you want change it, you can set the **Encoding** property

```
fileManager.Encoding = Encoding.Unicode;
```

Alternatively, the setting can be made with the instantiation

```
var fileManager = T4FileManager.Create(this).SetOutputFileEncoding(Encoding.Unicode);
```