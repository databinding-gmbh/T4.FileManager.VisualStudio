using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Helper
{
    public static class VisualStudioHelper
    {
        private static readonly DTE dte = DteUtil.GetCurrentDte();

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
                        cleanupItems.AddRange(items.Where(n => n.Name.EndsWith(extension)));
                }

                foreach (var item in cleanupItems)
                {
                    var fullPath = GetProjectItemFullPath(item);

                    item.Remove();

                    if (File.Exists(fullPath)) File.Delete(fullPath);
                }

                foreach (var projectName in projectNames)
                {
                    var projectPath = GetProjectDirectory(projectName);
                    foreach (var extension in extensions)
                    foreach (var file in Directory.EnumerateFiles(projectPath,
                        $"*{extension}",
                        SearchOption.AllDirectories))
                        File.Delete(file);
                }
            });
        }

        public static string GetCustomToolByFileName(string name, string projectName)
        {
            string customTool = null;

            RetryUtil.RetryOnException(() =>
            {
                var item = dte.Solution.FindProjectItem(name);
                if (item != null) customTool = item.Properties.Item("CustomTool").Value;
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

        public static void SaveFileAutomaticallyRunCustomTool(ProjectItem item)
        {
            RetryUtil.RetryOnException(() =>
            {
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

        public static ProjectItem AddFileToProject(string projectName,
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
                    throw new ArgumentException("The property CustomTool was not found.");

                property.Value = customTool;
            });

            return projectItem;
        }

        private static IEnumerable<ProjectItem> GetAllProjectItemsRecursive(ProjectItems projectItems)
        {
            foreach (ProjectItem projectItem in projectItems)
            {
                foreach (var subItem in GetAllProjectItemsRecursive(projectItem.ProjectItems)) yield return subItem;

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