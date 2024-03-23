using System.Drawing.Imaging;
using System.IO;

using NUnit.Framework;
using Reqnroll;
using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    [Binding]
    public class TestSetup
    {
        private readonly ScenarioContext context;

        private readonly IReqnrollOutputHelper outputHelper;

        public TestSetup(ScenarioContext scenarioContext, IReqnrollOutputHelper outputHelper)
        {
            this.context = scenarioContext;
            this.outputHelper = outputHelper;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            VisualStudioHelper.CleanupViaT4();
        }

        public void PrintReportInfo(string filename, string info)
        {
            this.outputHelper.AddAttachment(filename);
            this.outputHelper.WriteLine($" SCREENSHOT[ {filename} ]SCREENSHOT {info}");
        }

        public void TakeScreenshot(string info = "")
        {
            var mediaDir = CreateDirectoryName("media");
            var filename = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "_screen.png";
            var img = new ScreenCapture().CaptureScreen();
            img.Save(Path.Combine(mediaDir, filename), ImageFormat.Png);
            this.PrintReportInfo(@"media\" + filename, info);
        }

        [AfterStep]
        public void AfterStepActions()
        {

            if (this.context.TestError != null)
            {
                var error = $"Error: {this.context.ScenarioInfo.Title} - {this.context.TestError.Message}";
                this.TakeScreenshot(error);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.TakeScreenshot();
        }

        private static string CreateDirectoryName(string name)
        {
            var currentDir = TestContext.CurrentContext.WorkDirectory;
            var loggingDir = Path.Combine(currentDir, name);
            if (Directory.Exists(loggingDir) == false)
            {
                Directory.CreateDirectory(loggingDir);
            }

            return loggingDir;
        }
    }
}