namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using EnvDTE;

    public static class VisualStudioHelper
    {
        private static DTE dte = DteUtil.GetCurrentDte("T4.FileManager.NetCore.AcceptanceCriteria");

        public static bool CanOpenFileInCodeWindow { get; set; }

        public static void CleanupViaT4()
        {
            var solutionName = "T4.FileManager.NetCore.AcceptanceCriteria";
            var dte = DteUtil.GetCurrentDte(solutionName);
            var project = dte.Solution.Cast<Project>().First(p => p.Name == solutionName);
            var cleanup = GetAllProjectItemsRecursive(project.ProjectItems)
                .FirstOrDefault(p => p.Name.Contains("CleanUpTestoutput.tt"));

            if (cleanup != null)
            {
                cleanup.Open();
                cleanup.Save();
            }
        }

        public static void CleanupFiles(string[] projectNames, string[] extensions)
        {
            RetryUtil.RetryOnException(() =>
            {
                var cleanupItems = new List<ProjectItem>();

                foreach (var projectName in projectNames)
                {
                    var project = GetSolutionProjects().First(p => p.Name == projectName);

                    var items = GetAllProjectItemsRecursive(project.ProjectItems);

                    foreach (var extension in extensions)
                    {
                        cleanupItems.AddRange(items.Where(n => n.Name.EndsWith(extension)));
                    }
                }

                foreach (var item in cleanupItems)
                {
                    var fullPath = GetProjectItemFullPath(item);

                    item.Remove();

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                }

                foreach (var projectName in projectNames)
                {
                    var projectPath = GetProjectDirectory(projectName);
                    foreach (var extension in extensions)
                    {
                        foreach (var file in Directory.EnumerateFiles(
                            projectPath,
                            $"*{extension}",
                            SearchOption.AllDirectories))
                        {
                            File.Delete(file);
                        }
                    }
                }
            });
        }

        public static string GetCustomToolByFileName(string name, string projectName)
        {
            string customTool = null;

            RetryUtil.RetryOnException(() =>
            {
                var item = dte.Solution.FindProjectItem(name);
                if (item != null)
                {
                    customTool = item.Properties.Item("CustomTool").Value?.ToString();
                }
            });

            return customTool;
        }

        public static string GetProjectDirectory(string projectName)
        {
            string directory = null;

            RetryUtil.RetryOnException(() =>
            {
                var projectFilePath = GetSolutionProjects().First(p => p.Name.Contains(projectName))?.FullName;
                directory = Path.GetDirectoryName(projectFilePath);
            });

            return directory;
        }

        public static void ReplaceLineInProjectItem(ProjectItem item, string line, string replaceWith)
        {
            RetryUtil.RetryOnException(() =>
            {
                item.Document.ReplaceText(line, replaceWith);
                item.Save();
            });
        }

        public static void SaveFileAutomaticallyRunCustomTool(ProjectItem item)
        {
            RetryUtil.RetryOnException(() =>
            {
                if (CanOpenFileInCodeWindow && item.Document == null)
                {
                    var filePath = GetProjectItemFullPath(item);
                    dte.ItemOperations.OpenFile(filePath);
                }

                item.Open();
                item.Save();
            });
        }

        public static void RemoveFileFromProject(string fileName)
        {
            RetryUtil.RetryOnException(() =>
            {
                var projectItem = dte.Solution.FindProjectItem(fileName);
                projectItem?.Remove();
            });
        }

        public static void RecoverTemplateIfCorrupted(string path, string content)
        {
            RetryUtil.RetryOnException(() =>
            {
                // EnvDTE in .NET 5 can lost content of the template
                var template = File.ReadAllText(path);

                if (string.IsNullOrWhiteSpace(template))
                {
                    dte.ItemOperations.OpenFile(path);
                    dte.ActiveDocument.Close();
                    File.WriteAllText(path, content);
                    dte.ItemOperations.OpenFile(path);
                }
            });
        }
        
        public static ProjectItem AddFileToProject(string projectName, string fileName)
        {
            ProjectItem projectItem = null;

            RetryUtil.RetryOnException(() =>
            {
                var project = GetSolutionProjects().First(n => n.Name == projectName);
                var path = Path.GetFullPath(fileName);
                projectItem = project.ProjectItems.AddFromFile(path);
            });

            return projectItem;
        }

        public static ProjectItems GetProjectItemsFromProject(string projectName)
        {
            ProjectItems projectItems = null;
            RetryUtil.RetryOnException(() =>
            {
                var project = GetSolutionProjects().First(n => n.Name == projectName);
                projectItems = project.ProjectItems;
            });

            return projectItems;
        }

        public static Project AddProject(string pathToProject)
        {
            Project project = null;

            RetryUtil.RetryOnException(() =>
            {
                project = dte.Solution.AddFromFile(pathToProject, false);
            });

            return project;
        }

        public static void RemoveProject(Project project)
        {
            if (project == null)
            {
                return;
            }

            RetryUtil.RetryOnException(() =>
            {
                dte.Solution.Remove(project);
            });
        }

        private static IEnumerable<ProjectItem> GetAllProjectItemsRecursive(ProjectItems projectItems)
        {
            foreach (ProjectItem projectItem in projectItems)
            {
                foreach (var subItem in GetAllProjectItemsRecursive(projectItem.ProjectItems))
                {
                    yield return subItem;
                }

                yield return projectItem;
            }
        }

        private static IEnumerable<Project> GetSolutionProjects()
        {
            IEnumerable<Project> projects = null;

            RetryUtil.RetryOnException(() => { projects = dte.Solution.Projects.Cast<Project>(); });

            return projects;
        }

        private static string GetProjectItemFullPath(ProjectItem item)
        {
            return item.Properties.Item("FullPath").Value.ToString();
        }
    }
}