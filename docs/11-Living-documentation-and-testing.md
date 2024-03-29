# Living documentation and testing

The old version of T4.FileManager had bugs in new versions of Visual Studio that where hard to detect. To prevent this from happening again, we decided to develop the new version with BDD and functional tests that run inside Visual Studio. A nice benefit of this approach is that all features of T4.FileManager can be found in the examples section, including screenshots on how this should look in Visual Studio. 

## NET Framework

The latest functional testreport with screenshots based on Specification by Example can be found [here](../T4.FileManager.AcceptanceCriteria.dll.html).

## NET Core/NET 5.0+

The latest functional testreport with screenshots for NET 5+ based on Specification by Example that can be found [here](../T4.FileManager.NetCore.AcceptanceCriteria.dll.html)

### Lessons learned 

The following scenarios of feature **UT001 Generate Code** have a different behavior:

- Generate files ignores output extension .cs and uses .txt as default to avoid "error generation output" compile errors
- Generate files with DisableTemplateMainOutputFile enabled prevents generation of the t4 main output file (Workaround invalid file extension)

To find such differences in behaviors in Visual Studio 2019/2022 our functional tests were a great help to us.



