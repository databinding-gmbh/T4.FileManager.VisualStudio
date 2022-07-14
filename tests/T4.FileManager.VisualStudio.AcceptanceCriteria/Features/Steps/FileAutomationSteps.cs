namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    using System.Collections.Generic;
    using System.IO;

    using EnvDTE;

    using FluentAssertions;

    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Dto;
    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;

    using TechTalk.SpecFlow;

    [Binding]
    public class FileAutomationSteps
    {
        private string projectName = "T4.FileManager.VisualStudio.AcceptanceCriteria";
        private string pathTestEnvironment;
        private ProjectItem t4Template;
        private string targetTestPath;
        private string currentTesteeFilePath;

        [Given(@"the file manager")]
        public void GivenTheFileManager()
        {
            this.pathTestEnvironment =
                VisualStudioHelper.GetProjectDirectory("T4.FileManager.VisualStudio.AcceptanceCriteria");
            var pathSource = Path.Combine(pathTestEnvironment, "..\\..\\", "src\\");

            var fileManagerFromSource = Path.Combine(pathSource, "T4.FileManager.VisualStudio.ttinclude");
            var fileManagerForTest = Path.Combine(this.pathTestEnvironment, "T4.FileManager.VisualStudio.ttinclude");

            File.Copy(fileManagerFromSource, fileManagerForTest, true);

            fileManagerFromSource = Path.Combine(pathSource, "T4.FileManager.VisualStudio19.ttinclude");
            fileManagerForTest = Path.Combine(this.pathTestEnvironment, "T4.FileManager.VisualStudio19.ttinclude");

            File.Copy(fileManagerFromSource, fileManagerForTest, true);

            this.targetTestPath = this.pathTestEnvironment;
        }

        [Given(@"I select the target project ""(.*)""")]
        public void GivenTargetProjectForToGenerateFiles(string name)
        {
            this.projectName = name;
            this.targetTestPath = Path.Combine(this.targetTestPath, "..\\", this.projectName);
        }

        [Given(@"the script ""(.*)"" with the following content")]
        public void GivenTheScriptWithFollowingContentForAutomation(string filename, string templateContent)
        {
            this.currentTesteeFilePath = Path.Combine(this.pathTestEnvironment, filename);
            File.WriteAllText(this.currentTesteeFilePath, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                this.currentTesteeFilePath);
        }

        [Given(@"I change the line")]
        [When(@"I change the line")]
        public void GivenIChangeTheLine(IList<TemplateChanges> changes)
        {
            foreach (var change in changes)
            {
                VisualStudioHelper.ReplaceLineInProjectItem(this.t4Template, change.From, change.To);
            }
        }

        [When(@"I run the script")]
        [When(@"I run the script again")]
        [Given(@"I run the script")]
        public void WhenIRunTheScriptForAutomation()
        {
            VisualStudioHelper.CanOpenFileInCodeWindow = true;
            VisualStudioHelper.SaveFileAutomaticallyRunCustomTool(this.t4Template);
        }

        [Given(@"the following files are generated:")]
        [Then(@"the following files are generated:")]
        [Then(@"the following files exists:")]
        public void ThenFollowingFilesExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = file.GetFullPath(this.targetTestPath);

                if (string.IsNullOrWhiteSpace(file.ContainsContent) == false)
                {
                    var testeeContent = File.ReadAllText(testee);
                    testeeContent.Should().Contain(file.ContainsContent);
                }

                File.Exists(testee).Should().BeTrue();
            }
        }

        [Then(@"the following files are not generated:")]
        [Then(@"the following files no longer exist:")]
        [Then(@"the following files are cleaned up:")]
        public void ThenFollowingFilesNotExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = file.GetFullPath(this.targetTestPath);

                File.Exists(testee).Should().BeFalse();
            }
        }

        [Then(@"the custom tool is set to ""(.*)"" for the following files:")]
        public void ThenCustomToolIsSet(string customTool, IList<GeneratedFile> files)
        {
            foreach (var testee in files)
            {
                VisualStudioHelper.GetCustomToolByFileName(testee.Name, this.projectName).Should().Be(customTool);
            }
        }

        [Then(@"the file ""(.*)"" has following format:")]
        [Then(@"the file ""(.*)"" starts with header:")]
        public void ThenTheFileStartsWithFollowingContent(string file, string expectedContent)
        {
            var filePath = Path.Combine(this.targetTestPath, file);
            var testee = File.ReadAllText(filePath);
            
            testee.Should().StartWith(expectedContent);
        }

        [Then(@"the file ""(.*)"" contains following log fragments")]
        public void ThenTheFileContainsFollowingLogFragments(string file, IList<LogOutput> expectedContent)
        {
            var testee = File.ReadAllText(Path.Combine(this.pathTestEnvironment, file));
            foreach (var expected in expectedContent)
            {
                testee.Should().Contain(expected.Textfragment);
            }
        }

        [Then(@"the file ""([^""]*)"" is encoded in ""([^""]*)""")]
        public void ThenTheFileIsEncodedIn(string file, string expectedEncodingString)
        {
            var path = Path.Combine(this.targetTestPath, file);
            var expectedEncoding = FileEncodingHelper.ConvertStringToEncoding(expectedEncodingString);
            var actualEncoding = FileEncodingHelper.GetEncoding(path);

            actualEncoding.HeaderName.Should().Be(expectedEncoding.HeaderName);
        }
    }
}