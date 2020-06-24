using TechTalk.SpecFlow.Assist.Attributes;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Hooks
{
    public class GeneratedFile
    {
        [TableAliases("File")]
        public string Name { get; set; }

        public string Folder { get; set; }

        [TableAliases("Enthält", "Contains")]
        public string ContainsContent { get; set; }
    }
}