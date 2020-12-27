namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
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
    }
}