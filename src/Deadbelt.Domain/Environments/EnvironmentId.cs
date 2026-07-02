namespace Deadbelt.Domain.Environments;

public readonly record struct EnvironmentId
{
    public EnvironmentId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Environment ID cannot be empty.", nameof(value));

        Value = value;
    }

    public Guid Value { get; }

    public static EnvironmentId New()
    {
        return new EnvironmentId(Guid.NewGuid());
    }

    public static EnvironmentId From(Guid value)
    {
        return new EnvironmentId(value);
    }

    public override string ToString()
    {
        return Value.ToString("D");
    }
}