# T4.FileManager.VisualStudio

![Build Status](https://dev.azure.com/databinding/Building%20Blocks/_apis/build/status/T4.FileManager?branchName=master) [![Nuget](https://img.shields.io/nuget/v/T4.FileManager.VisualStudio)](https://www.nuget.org/packages/T4.FileManager.VisualStudio/)

Go to the [wiki](https://github.com/databinding-gmbh/T4.FileManager.VisualStudio/wiki) for detailed documentation.

## Getting Started

### Prerequisites

| Program | Version | Link | Info |
|-------------|-------------|-----|--|
| Visual Studio Community | 2017, 2019 | https://visualstudio.microsoft.com/vs/ | N/A

### Installing

Install the nuget package in your project.

```
Install-Package T4.FileManager.VisualStudio
```

For more information see [wiki](https://github.com/databinding-gmbh/T4.FileManager.VisualStudio/wiki).

## Running

The execution of the generation remains on the original T4 Text Templates (https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2019).

## Testing

There are some user story oriented SpecFlow test for ensuring that the FileManager is working as expected.
These tests are located in the project  `T4.FileManager.VisualStudio.AcceptanceCriteria`.

## Authors

- Thierry Iseli - *Inital work* - [Thierry Iseli (databinding)](https://github.com/databinding-thierryiseli)  

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Built With

- [T4 Text Templates](https://docs.microsoft.com/en-us/visualstudio/modeling/)
- [Json.NET](https://www.newtonsoft.com/json)

## Breaking changes to old FileManager

- No support for TFS version control
- *.txt4 is now named *.info.json
  
Link to old FileManager: https://github.com/renegadexx/T4.Helper.
