using System.IO;
using Reqnroll.Assist.Attributes;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Dto
{
    public class GeneratedFile
    {
        [TableAliases("File")]
        public string Name { get; set; }

        [TableAliases("Folder", "Project")]
        public string Folder { get; set; }

        public string BuildAction { get; set; }

        [TableAliases("Enthält", "Contains")]
        public string ContainsContent { get; set; }

        public string GetFullPath(string workingDirectory)
        {
            return Path.Combine(workingDirectory, this.Folder ?? string.Empty, this.Name);
        }
    }
}