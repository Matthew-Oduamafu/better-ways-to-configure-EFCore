using Better.Way.To.Configure.EFCore.Data;
using Better.Way.To.Configure.EFCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

builder.Services.AddDbContext<EfCoreDbContext>(
    (serviceProvider, dbContextOptionBuilder) =>
    {
        var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

        dbContextOptionBuilder.UseSqlServer(databaseOptions.DbConnectionString,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    databaseOptions.MaxRetryCount,
                    TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                    databaseOptions.ErrorNumbersToAdd
                );
                sqlOptions.CommandTimeout(databaseOptions.CommandTimeout);
            });

        dbContextOptionBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        dbContextOptionBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();