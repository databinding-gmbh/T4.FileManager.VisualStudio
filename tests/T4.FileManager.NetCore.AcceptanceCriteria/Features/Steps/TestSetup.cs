namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Steps
{
    using System;
    using System.Drawing.Imaging;
    using System.IO;

    using T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper;
    using T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper.Capture;

    using TechTalk.SpecFlow;

    [Binding]
    public class TestSetup
    {
        private readonly ScenarioContext context;

        public TestSetup(ScenarioContext scenarioContext)
        {
            this.context = scenarioContext;
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            VisualStudioHelper.CleanupViaT4();
        }

        public static void PrintReportInfo(string filename, string info)
        {
            Console.WriteLine($" SCREENSHOT[ {filename} ]SCREENSHOT {info}");
        }

        public static void TakeScreenshot(string info = "")
        {
            var filename = "_a" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "_screen.png";
            var img = new ScreenCapture().CaptureScreen();
            img.Save(filename, ImageFormat.Png);
            PrintReportInfo(filename, info);
        }

        [AfterStep]
        public void AfterStepActions()
        {
            if (this.context.TestError != null)
            {
                var error = $"Error: {this.context.ScenarioInfo.Title} - {this.context.TestError.Message}";
                TakeScreenshot(error);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TakeScreenshot();
        }
    }
}