namespace Deadbelt.Application.Workspaces;

public interface IWorkspaceService
{
    Task<CreateWorkspaceResult> CreateWorkspaceAsync(
        CreateWorkspaceRequest request,
        CancellationToken cancellationToken = default);
}