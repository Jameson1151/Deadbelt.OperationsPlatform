using Deadbelt.Domain.Environments;

namespace Deadbelt.Desktop.Services;

public sealed class EnvironmentDialogResult
{
    private EnvironmentDialogResult(
        bool confirmed,
        string name,
        string? description,
        GameType gameType)
    {
        Confirmed = confirmed;
        Name = name;
        Description = description;
        GameType = gameType;
    }

    public bool Confirmed { get; }

    public string Name { get; }

    public string? Description { get; }

    public GameType GameType { get; }

    public static EnvironmentDialogResult Cancelled()
    {
        return new EnvironmentDialogResult(false, string.Empty, null, GameType.Unknown);
    }

    public static EnvironmentDialogResult Success(
        string name,
        string? description,
        GameType gameType)
    {
        return new EnvironmentDialogResult(true, name, description, gameType);
    }
}