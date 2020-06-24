using System.IO;
using T4.FileManager.VisualStudio.AcceptanceCriteria.Helper;
using TechTalk.SpecFlow;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Steps
{
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