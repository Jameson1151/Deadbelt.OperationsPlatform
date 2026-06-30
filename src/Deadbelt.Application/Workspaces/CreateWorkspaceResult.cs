using Deadbelt.Domain.Workspaces;

namespace Deadbelt.Application.Workspaces;

public sealed class CreateWorkspaceResult
{
    private CreateWorkspaceResult(
        bool succeeded,
        Workspace? workspace,
        string? errorMessage)
    {
        Succeeded = succeeded;
        Workspace = workspace;
        ErrorMessage = errorMessage;
    }

    public bool Succeeded { get; }

    public Workspace? Workspace { get; }

    public string? ErrorMessage { get; }

    public static CreateWorkspaceResult Success(Workspace workspace)
    {
        return new CreateWorkspaceResult(true, workspace, null);
    }

    public static CreateWorkspaceResult Failure(string errorMessage)
    {
        return new CreateWorkspaceResult(false, null, errorMessage);
    }
}