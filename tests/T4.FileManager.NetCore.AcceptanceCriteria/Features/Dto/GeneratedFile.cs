namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Dto
{
    using System.IO;

    using TechTalk.SpecFlow.Assist.Attributes;

    public class GeneratedFile
    {
        [TableAliases("File")]
        public string Name { get; set; }

        public string Folder { get; set; }

        [TableAliases("Enthält", "Contains")]
        public string ContainsContent { get; set; }

        public string GetFullPath(string workingDirectory)
        {
            return Path.Combine(workingDirectory, this.Folder ?? string.Empty, this.Name);
        }
    }
}