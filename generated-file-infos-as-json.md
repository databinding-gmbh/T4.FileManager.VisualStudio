# generated file infos as json

If you want to see what files your t4 generates, there should be a *.json-File next to your *.tt-File (\*.info.json). It contains a list of all file infos of your generated files. The *.json-File is also used to clean up the files if there should be path changes after regenerating files in this step `fileManager.Generate()`  or `fileManager.Process()`.

```
your-file.tt
your-file.info.json
```

Content example:

```
{
   "FilesToGenerate":[
      {
         "Filename":"SimpleLimousine.g.cs",
         "Project":null,
         "Path":"SimpleFiles",
         "Properties":{

         }
      },
      {
         "Filename":"SimpleVan.g.cs",
         "Project":null,
         "Path":"SimpleFiles",
         "Properties":{

         }
      },
      {
         "Filename":"SimpleCoupe.g.cs",
         "Project":null,
         "Path":"SimpleFiles",
         "Properties":{

         }
      }
   ]
}
```