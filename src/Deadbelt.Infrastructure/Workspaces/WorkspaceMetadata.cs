namespace Deadbelt.Infrastructure.Workspaces;

internal sealed class WorkspaceMetadata
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required DateTime CreatedUtc { get; init; }

    public required string Version { get; init; }
}