<p align="center">
  <img height="150" src="https://raw.githubusercontent.com/databinding-gmbh/T4.FileManager.VisualStudio/master/src/images/logo-t4-file-manager.png" alt="T4 FileManager"/>
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
| Overwrite Existing File                | Overwrite previously generated files.                        |
| File Properties                        | Specify file properties like CustomTool or BuildAction.      |
| [File Header](05-Add-header-to-files.md)                            | Create a custom header in your generated files.              |
| Logging                                | Debug problems in your templates with the verbose log of T4.FileManager. |
| Disable main output file               | Tell T4.FileManager not to create a main output file.        |
| Code Generation                        | Put each generated class into a separate file.               |
| Support for subfolders                 | Generate files inside subfolders.                            |
| Support for projects                   | Generate files in different projects of your solution.       |
| Shortcut support (Edit.FormatDocument) | Cleanup the generated files to your coding standards.        |

### Installing and Usage

1. [Installation](01-Installation.md)
2. [Include in your text template](02-Include-in-your-text-template.md)
3. [Create instance](03-Create-instance.md)
4. [Start or create file](04-Start-or-create-file.md)
5. [Add header to files](05-Add-header-to-files.md)
6. [Proceed to generate files](06-Proceed-to-generate-files.md)   
7. [Features](07-Features.md)
8. [Generated file infos as json](08-Generated-file-infos-as-json.md)
9. [Living documentation and testing](09-Living-documentation-and-testing.md)
10. [Change log](10-Change-log.md)
