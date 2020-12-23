namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Hooks
{
    using TechTalk.SpecFlow.Assist.Attributes;

    public class GeneratedFile
    {
        [TableAliases("File")]
        public string Name { get; set; }

        public string Folder { get; set; }

        [TableAliases("Enthält", "Contains")]
        public string ContainsContent { get; set; }
    }
}