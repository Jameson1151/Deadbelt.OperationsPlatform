using System.Text.Json;
using Deadbelt.Application.Workspaces;
using Deadbelt.Domain.Workspaces;

namespace Deadbelt.Infrastructure.Workspaces;

public sealed class JsonWorkspaceStore : IWorkspaceStore
{
    private const string WorkspaceFileName = "workspace.json";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    public async Task SaveAsync(
        Workspace workspace,
        CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(workspace.Path);

        var workspaceFilePath = Path.Combine(workspace.Path, WorkspaceFileName);

        if (File.Exists(workspaceFilePath))
        {
            throw new InvalidOperationException(
                $"A workspace already exists at '{workspace.Path}'.");
        }

        var metadata = new WorkspaceMetadata
        {
            Name = workspace.Name,
            Description = workspace.Description,
            CreatedUtc = workspace.CreatedUtc,
            Version = workspace.Version
        };

        await using var stream = File.Create(workspaceFilePath);

        await JsonSerializer.SerializeAsync(
            stream,
            metadata,
            JsonOptions,
            cancellationToken);
    }
}
