namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    using System.Collections.Generic;
    using System.IO;

    using EnvDTE;

    using FluentAssertions;

    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;
    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Hooks;

    using TechTalk.SpecFlow;

    [Binding]
    class FileAutomationSteps
    {
        private string projectName = "T4.FileManager.VisualStudio.AcceptanceCriteria";
        private string sourcePath;
        private ProjectItem t4Template;
        private string targetTestPath;
        private IList<GeneratedFile> files;
        private string currentTesteeFilePath;

        [Given(@"the file manager")]
        public void GivenTheFileManager()
        {
            var pathDestination =
                VisualStudioHelper.GetProjectDirectory("T4.FileManager.VisualStudio.AcceptanceCriteria");
            var pathSource = Path.Combine(pathDestination, "..\\..\\", "src\\");

            var fmSource = Path.Combine(pathSource, "T4.FileManager.VisualStudio.ttinclude");
            var fmDest = Path.Combine(pathDestination, "T4.FileManager.VisualStudio.ttinclude");

            File.Copy(fmSource, fmDest, true);

            this.sourcePath = pathDestination;
            this.targetTestPath = pathDestination;
        }

        [Given(@"for target project ""(.*)"" to generate files")]
        public void GivenTargetProjectForToGenerateFiles(string name)
        {
            this.projectName = name;
            this.targetTestPath = Path.Combine(this.targetTestPath, "..\\", this.projectName);
        }

        [Given(@"the script ""(.*)"" with following content for automation")]
        public void GivenTheScriptWithFollowingContentForAutomation(string filename, string templateContent)
        {
            this.currentTesteeFilePath = Path.Combine(this.sourcePath, filename);
            File.WriteAllText(this.currentTesteeFilePath, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                this.currentTesteeFilePath);
        }

        [Given(@"the script ""(.*)"" modified by following content:")]
        public void GivenTheScriptModifiedByFollowingContent(string filename, string templateContent)
        {
            var file = Path.Combine(this.sourcePath, filename);

            VisualStudioHelper.RemoveFileFromProject(file);

            File.WriteAllText(file, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                file);
        }

        [Given(@"i change the line")]
        public void GivenIChangeTheLine(IList<TemplateChanges> changes)
        {
            var template = File.ReadAllText(this.currentTesteeFilePath);
            foreach (var change in changes)
            {
                template = template.Replace(change.From, change.To);
            }

            this.GivenTheScriptModifiedByFollowingContent(this.currentTesteeFilePath, template);
        }

        [Given(@"i run the script for automation")]
        [When(@"i run the script for automation again")]
        [When(@"i run the script for automation")]
        public void WhenIRunTheScriptForAutomation()
        {
            VisualStudioHelper.SaveFileAutomaticallyRunCustomTool(this.t4Template);
        }

        [Given(@"following files are generated:")]
        [Then(@"following files are generated:")]
        [Then(@"following files exists:")]
        public void ThenFollowingFilesExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = Path.Combine(this.targetTestPath, file.Folder ?? "", file.Name);

                if (string.IsNullOrWhiteSpace(file.ContainsContent) == false)
                {
                    var testeeContent = File.ReadAllText(testee);
                    testeeContent.Should().Contain(file.ContainsContent);
                }

                File.Exists(testee).Should().BeTrue();
            }

            this.files = files;
        }

        [Then(@"the following files no longer exist:")]
        [Then(@"following files are cleaned up:")]
        public void ThenFollowingFilesNotExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = Path.Combine(this.targetTestPath, file.Folder ?? "", file.Name);

                File.Exists(testee).Should().BeFalse();
            }
        }

        [Then(@"custom tool is set to ""(.*)"" for following files:")]
        public void ThenCustomToolIsSet(string customTool, IList<GeneratedFile> files)
        {
            foreach (var testee in files)
                VisualStudioHelper.GetCustomToolByFileName(testee.Name, this.projectName).Should().Be(customTool);
        }

        [Then(@"all files contains following content:")]
        public void ThenAllFilesContainsFollowingContent(string content)
        {
            foreach (var file in this.files)
            {
                var fullPath = Path.Combine(this.targetTestPath, file.Folder ?? "", file.Name);
                var testee = File.ReadAllText(fullPath);
                testee.Contains(content).Should().BeTrue();
            }
        }
    }
}