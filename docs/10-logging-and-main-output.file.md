# Logging and main output file

You can modify where T4.FileManager write its logs to and disable the main output file.



## Logging

To turn on logging you need to create your T4.FileManager instance with this command:



`var fileManager = new T4FileManager(this).EnableLog();`



You now get a log with all important steps of the file generation in the output window of Visual Studio and in the file ***yourTemplate.txt***.



You can write your own log messages with the *Log()* method:

`<# fileManager.Log("My custom log info for {0}", itm); #>`





## Disable main output file

By default T4.FileManager creates a template main output file *YourTemplateName.txt*. If you want to disable it, you need to create your T4.FileManager instance with this command:



`var fileManager = T4FileManager.Create(this).DisableTemplateMainOutputFile();`

 

