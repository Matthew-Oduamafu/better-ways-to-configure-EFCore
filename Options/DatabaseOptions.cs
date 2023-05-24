namespace Better.Way.To.Configure.EFCore.Options;

public record DatabaseOptions
{
    public string? DbConnectionString { get; set; } = null!;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public IEnumerable<int>? ErrorNumbersToAdd { get; set; } = null;
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}