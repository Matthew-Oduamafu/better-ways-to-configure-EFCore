using Microsoft.Extensions.Options;

namespace Better.Way.To.Configure.EFCore.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        var connString = _configuration.GetConnectionString("DefaultConn");

        options.DbConnectionString = connString;
        
        _configuration.GetSection(nameof(DatabaseOptions)).Bind(options);
    }
}