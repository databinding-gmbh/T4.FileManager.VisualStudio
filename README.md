# T4.FileManager.VisualStudio

[![Build Status](https://dev.azure.com/databinding/Building%20Blocks/_apis/build/status/databinding-gmbh.T4.FileManager.VisualStudio?branchName=master)](https://dev.azure.com/databinding/Building%20Blocks/_build/latest?definitionId=39&branchName=master) [![Nuget](https://img.shields.io/nuget/v/T4.FileManager.VisualStudio)](https://www.nuget.org/packages/T4.FileManager.VisualStudio/)

 

## Documentation

Our [documentation](https://databinding-gmbh.github.io/T4.FileManager.VisualStudio/) offers all the details you need to know to work with T4.FileManager.



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

For more information see [documentation](https://databinding-gmbh.github.io/T4.FileManager.VisualStudio/01-Installation/).

## Running

The execution of the generation remains on the original T4 Text Templates (https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2019).

## Testing

There are some user story oriented [SpecFlow tests](https://databinding-gmbh.github.io/T4.FileManager.VisualStudio/T4FileManagerVisualStudio.html) for ensuring that the FileManager is working as expected.
These tests are located in the project  `T4.FileManager.VisualStudio.AcceptanceCriteria`.

## Authors

- René Leupold - *initial work*
- Thierry Iseli - *Consolidation of [T4.TemplateFileManager](https://github.com/renegadexx/T4.Helper)*
- Johnny Graber

## How to Contribute

Pull-requests are welcome! Please follow these rules so that we can integrate your pull-requests without much effort:

* Create an issue and explain the problem with an example
*	Reference the issue in your commits / pull-request
*	Document the new behavior (in the docs folder)
*	Create tests to verify the new behavior
*	[All existing tests must still pass](https://databinding-gmbh.github.io/T4.FileManager.VisualStudio/T4FileManagerVisualStudio.html), including the acceptance tests (in the tests folder)
*	Clean-up the commit history 
    *	No fix commits
    *	Changes that belong together are in the same commit
    *	All commits have a meaningful commit message
* Keep the code maintainable and focused on the problem you try to solve
    *	No feature-flags to turn the main logic on or off
    *	No C# preprocessor directives (like #if DEBUG)
    *	No modification of the author list (on GitHub and in the NuGet package)
    *	No changes on the code style and formatting



## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Built With

- [T4 Text Templates](https://docs.microsoft.com/en-us/visualstudio/modeling/)
- [Json.NET](https://www.newtonsoft.com/json)

## Breaking changes to old FileManager

- No support for TFS version control
- *.txt4 is now named *.info.json
  
Link to old T4.TemplateFileManager: https://github.com/renegadexx/T4.Helper.
