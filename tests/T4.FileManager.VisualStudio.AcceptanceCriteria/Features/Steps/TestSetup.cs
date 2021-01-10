namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    using System.Drawing.Imaging;
    using System.IO;

    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;

    using TechTalk.SpecFlow;

    [Binding]
    public class TestSetup
    {
        [AfterTestRun]
        public static void AfterTestRun()
        {
            VisualStudioHelper.CleanupViaT4();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var path = "_" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".png";
            var img = new ScreenCapture().CaptureScreen();
            img.Save(path, ImageFormat.Png);
        }
    }
}