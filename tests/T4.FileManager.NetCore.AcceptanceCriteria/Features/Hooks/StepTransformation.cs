using System.Collections.Generic;
using System.Linq;

using Reqnroll;

using T4.FileManager.NetCore.AcceptanceCriteria.Features.Dto;

namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Hooks
{
    [Binding]
    public class StepTransformation
    {
        [StepArgumentTransformation]
        public IList<GeneratedFile> GenerateFileTransform(Table table)
        {
            return table.CreateSet<GeneratedFile>().ToList(); 
        }

        [StepArgumentTransformation]
        public IList<TemplateChanges> TemplateChangeTransform(Table table)
        {
            return table.CreateSet<TemplateChanges>().ToList();
        }

        [StepArgumentTransformation]
        public IList<LogOutput> LogOutputTransform(Table table)
        {
            return table.CreateSet<LogOutput>().ToList();
        }
    }
}