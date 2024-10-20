using System.IO;

namespace Editor.Utilities;

public class PathValidator
{
    public static bool ValidateProjectName(string projectName, out string errorMsg)
    {
        errorMsg = string.Empty;

        if (string.IsNullOrWhiteSpace(projectName.Trim()))
        {
            errorMsg = "Type in a project name.";
            return false;
        }

        if (projectName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
        {
            errorMsg = "Invalid character(s) used in project name.";
            return false;
        }

        return true;
    }
    
    public static bool ValidateProjectPath(string projectPath, out string errorMsg)
    {
        errorMsg = string.Empty;

        if (string.IsNullOrWhiteSpace(projectPath.Trim()))
        {
            errorMsg = "Select a valid project folder.";
            return false;
        }

        if (projectPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
        {
            errorMsg = "Invalid character(s) used in project path.";
            return false;
        }

        return true;
    }
    
    public static bool ValidateDirectory(string path, out string errorMsg)
    {
        errorMsg = string.Empty;

        if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
        {
            errorMsg = "Selected project folder already exists and is not empty.";
            return false;
        }

        return true;
    }
    
    public static string BuildFullPath(string projectPath, string projectName)
    {
        if (!Path.EndsInDirectorySeparator(projectPath))
        {
            projectPath += @"\";
        }
        return projectPath + projectName;
    }
}