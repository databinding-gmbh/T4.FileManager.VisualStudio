# Change log

## 2.0.0

- Compatibility to T4.TemplateFileManager improved
- Added class **TemplateFileManager** for better backward compatibility
- Header supports the placeholder $filename$ again
- Methods to configure the t4 file manager now follow the builder pattern style
- GetNamespaceForCSharpCode() removed because CreateNewFile knows the namespace already (set by developer)
- New logo

## 1.3.0

- Logging generation in output window and main output text file if .EnableLog() called (Feature UT016)

## 1.2.4

- Referencing in .net core projects new with $(TargetDir)

## Breaking Changes compared to TemplateFileManager

- No support for TFS Source Control
- No Parameter template support with sessions
- *.txt4 replaced with *.info.json
- WriteLineToBuildPane replaced with FileManager.Log()
- Disable split files (FileManager.Process) not supported

