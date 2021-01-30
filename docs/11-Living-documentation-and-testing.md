# Living documentation and testing

The old version of T4.FileManager had bugs in new versions of Visual Studio that where hard to detect. To prevent this from happening again, we decided to develop the new version with BDD and end 2 end tests that run inside Visual Studio. A nice benefit of this approach is that all features of T4.FileManager can be found in the examples section, including screenshots on how this should look in Visual Studio. 

The latest end 2 end test can be found [here](../T4FileManagerVisualStudio.html).