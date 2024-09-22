# Change log

## 4.0.2
- Bug Fix BuildAction #22 BUG: Wrong file property value set

## 4.0.1
- Newtonsoft.Json replaced by TemplateInfoSerializer due to dependency conflicts as of Visual Studio 17.11+

## 3.1.0

- Define Encoding for generated output files with .SetOutputFileEncoding(Encoding.Unicode). [Scenario: Generate file with Unicode encoding](https://github.com/databinding-gmbh/T4.FileManager.VisualStudio/blob/master/tests/T4.FileManager.NetCore.AcceptanceCriteria/Features/UT001-Generate_Code.feature) 

## 3.0.0

- Support for Visual Studio 2022

### Breaking Changes

Visual Studio has Breaking Changes in EnvDTE-Automation. With this version **T4.FileManager.VisualStudio.ttinclude** works **only** in Visual Studio **2022**.
For **backward compatibility** you can use T4.FileManager.VisualStudio**19**.ttinclude

## 2.0.0

- Compatibility to T4.TemplateFileManager improved
- Added class **TemplateFileManager** for better backward compatibility
- Header supports the placeholder $filename$ again
- Methods to configure the t4 file manager now follow the builder pattern style

### Breaking Changes

- GetNamespaceForCSharpCode() removed because CreateNewFile knows the namespace already (set by developer)
- CreateNewFile FileProperties Dictionary removed use class FileProperties instead

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

