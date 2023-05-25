<!-- # Entity Framework Core Configuration in ASP.NET

This guide explains a better way to configure Entity Framework Core in an ASP.NET project using the appsettings.json file.

## Overview -->

# Entity Framework Core Configuration in ASP.NET

This guide explains a better way to configure Entity Framework Core in an ASP.NET project, where configuration parameters are stored in the appsettings.json file.

## Overview

In an ASP.NET project, you can store configuration parameters in the appsettings.json file. To configure Entity Framework Core with these parameters, you can follow these steps:

1. Create a class to represent the configuration settings:

   ```csharp
   public class DatabaseOptions
   {
       public string ConnectionString { get; set; }
       // Add other configuration fields as needed
   }
   
<!-- 
1. Create a class to represent the configuration settings. -->

<!-- 2. Install the `Microsoft.Extensions.Configuration` NuGet package. -->
2. Install the Microsoft.Extensions.Configuration NuGet package to access configuration settings.

3. In the Startup.cs file, add the following code in the ConfigureServices method:
   ```csharp
    services.Configure<DatabaseOptions>(Configuration.GetSection("DatabaseSettings"));
    
4. Add the necessary configuration to the appsettings.json file:
   ```csharp
       {
      "DatabaseOptions": {
        "ConnectionString": "your_connection_string_here"
        // Add other configuration fields here
      },
      // Other app settings
    }

5. Inject the configured options into the DbContext class:
   ```csharp
      builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

    builder.Services.AddDbContext<YourDbContext>(
        (serviceProvider, dbContextOptionBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextOptionBuilder.UseSqlServer(databaseOptions.DbConnectionString
                });
                // other configurations
        });


With this approach, the configuration values from the appsettings.json file can be accessed at runtime and passed to the Entity Framework Core configuration.

__checkout the code to see how it is implemented__

<!-- 5. Configure the services in the `Startup.cs` file:

   ```csharp
   services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
   
   
   
4. Add the necessary configuration to the appsettings.json file.

5. Inject the configured options into the DbContext class.
 -->
