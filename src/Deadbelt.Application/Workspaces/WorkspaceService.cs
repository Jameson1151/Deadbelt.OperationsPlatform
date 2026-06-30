using Deadbelt.Domain.Workspaces;
using Microsoft.Extensions.Logging;

namespace Deadbelt.Application.Workspaces;

public sealed class WorkspaceService : IWorkspaceService
{
    private const string CurrentWorkspaceVersion = "0.1";

    private readonly IWorkspaceStore _workspaceStore;
    private readonly ILogger<WorkspaceService> _logger;

    public WorkspaceService(
        IWorkspaceStore workspaceStore,
        ILogger<WorkspaceService> logger)
    {
        _workspaceStore = workspaceStore;
        _logger = logger;
    }

    public async Task<CreateWorkspaceResult> CreateWorkspaceAsync(
        CreateWorkspaceRequest request,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return CreateWorkspaceResult.Failure("Workspace name is required.");

        if (string.IsNullOrWhiteSpace(request.FolderPath))
            return CreateWorkspaceResult.Failure("Workspace folder is required.");

        try
        {
            var workspace = new Workspace(
                request.Name,
                request.FolderPath,
                request.Description,
                DateTime.UtcNow,
                CurrentWorkspaceVersion);

            await _workspaceStore.SaveAsync(workspace, cancellationToken);

            _logger.LogInformation(
                "Workspace created: {WorkspaceName} at {WorkspacePath}",
                workspace.Name,
                workspace.Path);

            return CreateWorkspaceResult.Success(workspace);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create workspace.");

            return CreateWorkspaceResult.Failure(
                "Failed to create workspace. See logs for details.");
        }
    }
}