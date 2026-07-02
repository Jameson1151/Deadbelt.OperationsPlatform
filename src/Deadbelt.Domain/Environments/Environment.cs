namespace Deadbelt.Domain.Environments;

public sealed class Environment
{
    public Environment(
        EnvironmentId id,
        string workspacePath,
        string name,
        string? description,
        GameType gameType,
        string environmentPath,
        DateTime createdUtc,
        string version,
        EnvironmentStatus status = EnvironmentStatus.Draft)
    {
        if (id.Value == Guid.Empty)
            throw new ArgumentException("Environment ID is required.", nameof(id));

        if (string.IsNullOrWhiteSpace(workspacePath))
            throw new ArgumentException("Workspace path is required.", nameof(workspacePath));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Environment name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(environmentPath))
            throw new ArgumentException("Environment path is required.", nameof(environmentPath));

        if (string.IsNullOrWhiteSpace(version))
            throw new ArgumentException("Environment version is required.", nameof(version));

        if (!Enum.IsDefined(gameType))
            throw new ArgumentOutOfRangeException(nameof(gameType), gameType, "Invalid game type.");

        if (!Enum.IsDefined(status))
            throw new ArgumentOutOfRangeException(nameof(status), status, "Invalid environment status.");

        Id = id;
        WorkspacePath = workspacePath.Trim();
        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        GameType = gameType;
        EnvironmentPath = environmentPath.Trim();
        CreatedUtc = createdUtc;
        Version = version.Trim();
        Status = status;
    }

    public EnvironmentId Id { get; }

    public string WorkspacePath { get; }

    public string Name { get; }

    public string Description { get; }

    public GameType GameType { get; }

    public string EnvironmentPath { get; }

    public DateTime CreatedUtc { get; }

    public string Version { get; }

    public EnvironmentStatus Status { get; }
}