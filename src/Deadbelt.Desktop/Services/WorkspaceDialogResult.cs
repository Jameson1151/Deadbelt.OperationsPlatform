namespace Deadbelt.Desktop.Services;

public sealed class WorkspaceDialogResult
{
    private WorkspaceDialogResult(
        bool confirmed,
        string name,
        string folderPath,
        string? description)
    {
        Confirmed = confirmed;
        Name = name;
        FolderPath = folderPath;
        Description = description;
    }

    public bool Confirmed { get; }

    public string Name { get; }

    public string FolderPath { get; }

    public string? Description { get; }

    public static WorkspaceDialogResult Cancelled()
    {
        return new WorkspaceDialogResult(false, string.Empty, string.Empty, null);
    }

    public static WorkspaceDialogResult Success(
        string name,
        string folderPath,
        string? description)
    {
        return new WorkspaceDialogResult(true, name, folderPath, description);
    }
}