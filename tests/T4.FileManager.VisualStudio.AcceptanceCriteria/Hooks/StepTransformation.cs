using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Hooks
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
    }
}
