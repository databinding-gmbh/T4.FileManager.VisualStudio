using System;
using System.Drawing.Imaging;
using System.IO;
using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    [Binding]
    public class TestSetup
    {
        private readonly ScenarioContext context;

        private readonly ISpecFlowOutputHelper outputHelper;

        public TestSetup(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper)
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
            if (Directory.Exists("media") == false)
            {
                Directory.CreateDirectory("media");
            }

            var filename = @"media\_a" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "_screen.png";
            var img = new ScreenCapture().CaptureScreen();
            img.Save(filename, ImageFormat.Png);
            this.PrintReportInfo(filename, info);
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
    }
}