using Deadbelt.Domain.Workspaces;

namespace Deadbelt.Application.Workspaces;

public interface IWorkspaceStore
{
    Task SaveAsync(Workspace workspace, CancellationToken cancellationToken = default);
}