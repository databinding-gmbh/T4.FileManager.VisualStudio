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
            VisualStudioHelper.CleanupFiles(new[]
                {
                    "T4.FileManager.VisualStudio.AcceptanceCriteria.ExampleTestProject",
                    "T4.FileManager.VisualStudio.AcceptanceCriteria"
                },
                new[]
                {
                    ".tt",
                    ".g.cs",
                    ".g1.cs",
                    ".info.json",
                    ".txt"
                });
        }
    }
}