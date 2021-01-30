<p align="center">
  <img height="150" style="height:150px !important" src="https://raw.githubusercontent.com/databinding-gmbh/T4.FileManager.VisualStudio/master/src/images/logo-t4-file-manager.png" alt="T4 FileManager"/>
</p>

## T4.FileManager.VisualStudio

[![Build Status](https://dev.azure.com/databinding/Building%20Blocks/_apis/build/status/databinding-gmbh.T4.FileManager.VisualStudio?branchName=master)](https://dev.azure.com/databinding/Building%20Blocks/_build/latest?definitionId=39&branchName=master) [![Nuget](https://img.shields.io/nuget/v/T4.FileManager.VisualStudio)](https://www.nuget.org/packages/T4.FileManager.VisualStudio/)

With the T4.FileManager you can define into which files T4 generates your code. You are no longer bound to the default behaviour of T4 that generates all the code of the “example.tt” template into a single “example.cs” file. Now you can split your code into the files you want: 

- Putting each generated data class into a single code file
- Creating a server and a client component based on a common model
- Distribute generated code to multiple projects within a solution
- Set the file properties (like ResXFileCodeGenerator as CustomTool)
- Update previously generated files

### Features

| Feature                                | Description                                                  |
| -------------------------------------- | ------------------------------------------------------------ |
| [Code Generation](02-Quick-start.md)                        | Put each generated class into a separate file.               |
| [File Header](06-Add-header-to-files.md)                            | Create a custom header in your generated files.              |
| [Support for subfolders](05-Start-or-create-file.md)                 | Generate files inside subfolders.                            |
| [Support for projects](05-Start-or-create-file.md)                   | Generate files in different projects of your solution.       |
| [File Properties](05-Start-or-create-file.md#Properties)                        | Specify file properties like CustomTool or BuildAction.      |
| [Overwrite Existing File](05-Start-or-create-file.md#properties)                | Overwrite previously generated files.                        |
| [Shortcut support (Edit.FormatDocument)](08-Auto-indent-and-clean-up.md) | Cleanup the generated files to your coding standards.        |
| [Disable main output file](10-logging-and-main-output.file.md)               | Tell T4.FileManager not to create a main output file.        |
| [Logging](10-logging-and-main-output.file.md)                                | Debug problems in your templates with the verbose log of T4.FileManager. |


### Table of contents

1. [Installation](01-Installation.md)
2. [Quick start](02-Quick-start.md)
3. [Include in your text template](03-Include-in-your-text-template.md)
4. [Create instance](04-Create-instance.md)
5. [Start or create file](05-Start-or-create-file.md)
6. [Add header to files](06-Add-header-to-files.md)
7. [Proceed to generate files](07-Proceed-to-generate-files.md)   
8. [Auto indent and clean-up](08-Auto-indent-and-clean-up.md)
9. [Generated file infos as json](09-Generated-file-infos-as-json.md)
10. [Logging and main output file](10-logging-and-main-output.file.md)
11. [Living documentation and testing](11-Living-documentation-and-testing.md)
11. [Change log](12-Change-log.md)
