namespace Tool.Make.Common;

public static class DirectoryUtil
{
    public static bool TryGetSolutionDirectoryInfo(out DirectoryInfo directoryInfo, string? currentPath = null)
    {
        var directory = new DirectoryInfo(
            currentPath ?? Directory.GetCurrentDirectory());
        directoryInfo = directory;
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }

        if (directory is null) return false;
        directoryInfo = directory;

        return true;
    }
}