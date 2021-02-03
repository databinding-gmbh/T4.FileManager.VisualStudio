namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Steps
{
    using System.Collections.Generic;
    using System.IO;

    using EnvDTE;

    using FluentAssertions;

    using T4.FileManager.NetCore.AcceptanceCriteria.Features.Dto;
    using T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper;

    using TechTalk.SpecFlow;

    [Binding]
    public class FileAutomationSteps
    {
        private string projectName = "T4.FileManager.NetCore.AcceptanceCriteria";
        private string pathTestEnvironment;
        private ProjectItem t4Template;
        private string targetTestPath;
        private string currentTesteeFilePath;

        [Given(@"the file manager")]
        public void GivenTheFileManager()
        {
            this.pathTestEnvironment =
                VisualStudioHelper.GetProjectDirectory("T4.FileManager.NetCore.AcceptanceCriteria");

            var outputdir = Path.Combine(this.pathTestEnvironment, "bin\\debug\\net5.0\\");
            var pathSource = Path.Combine(this.pathTestEnvironment, "..\\..\\", "src\\");

            var fileManagerFromSource = Path.Combine(pathSource, "T4.FileManager.VisualStudio.ttinclude");
            var fileManagerForTest = Path.Combine(outputdir, "T4.FileManager.VisualStudio.ttinclude");

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

        [Given(@"the script ""(.*)"" modified by following content:")]
        public void GivenTheScriptModifiedByFollowingContent(string filename, string templateContent)
        {
            var file = Path.Combine(this.pathTestEnvironment, filename);

            VisualStudioHelper.RemoveFileFromProject(file);

            File.WriteAllText(file, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                file);
        }

        [Given(@"I change the line")]
        [When(@"I change the line")]
        public void GivenIChangeTheLine(IList<TemplateChanges> changes)
        {
            var template = File.ReadAllText(this.currentTesteeFilePath);
            foreach (var change in changes)
            {
                template = template.Replace(change.From, change.To);
            }

            this.GivenTheScriptModifiedByFollowingContent(this.currentTesteeFilePath, template);
        }

        [When(@"I run the script")]
        [When(@"I run the script again")]
        [Given(@"I run the script")]
        public void WhenIRunTheScriptForAutomation()
        {
            VisualStudioHelper.CanOpenFileInCodeWindow = false;
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
    }
}