namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using EnvDTE;

    public static class VisualStudioHelper
    {
        public static DTE Dte { get; internal set; } = DteUtil.GetCurrentDte();

        public static bool CanOpenFileInCodeWindow { get; set; }

        public static void CleanupViaT4()
        {
            var dte = DteUtil.GetCurrentDte();
            var project = dte.Solution.Cast<Project>().First(p => p.Name == "T4.FileManager.VisualStudio.AcceptanceCriteria");
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
                var item = Dte.Solution.FindProjectItem(name);
                if (item != null)
                {
                    customTool = item.Properties.Item("CustomTool").Value.ToString();
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
                    Dte.ItemOperations.OpenFile(filePath);
                }

                item.Open();
                item.Save();
            });
        }

        public static void RemoveFileFromProject(string fileName)
        {
            RetryUtil.RetryOnException(() =>
            {
                var projectItem = Dte.Solution.FindProjectItem(fileName);
                projectItem?.Remove();
            });
        }

        public static ProjectItem AddFileToProject(
            string projectName,
            string fileName,
            string customTool = "TextTemplatingFileGenerator")
        {
            ProjectItem projectItem = null;

            RetryUtil.RetryOnException(() =>
            {
                var project = GetSolutionProjects().First(n => n.Name == projectName);

                var path = Path.GetFullPath(fileName);

                projectItem = project.ProjectItems.AddFromFile(path);

                var property = projectItem.Properties.Item("CustomTool");

                if (property == null)
                {
                    throw new ArgumentException("The property CustomTool was not found.");
                }

                property.Value = customTool;
            });

            return projectItem;
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

            RetryUtil.RetryOnException(() => { projects = Dte.Solution.Projects.Cast<Project>(); });

            return projects;
        }

        private static string GetProjectItemFullPath(ProjectItem item)
        {
            return item.Properties.Item("FullPath").Value.ToString();
        }
    }
}