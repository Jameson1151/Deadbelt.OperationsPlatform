namespace Deadbelt.Application.Workspaces;

public sealed class CreateWorkspaceRequest
{
    public required string Name { get; init; }

    public required string FolderPath { get; init; }

    public string? Description { get; init; }
}