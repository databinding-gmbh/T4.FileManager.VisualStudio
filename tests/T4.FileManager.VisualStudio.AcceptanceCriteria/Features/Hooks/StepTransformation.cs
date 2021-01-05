namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Hooks
{
    using System.Collections.Generic;
    using System.Linq;

    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Dto;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

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