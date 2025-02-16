using ExerciseTracker.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((options,services) =>
{
    services.AddDbContextFactory<ExerciseDbContext>((optionsBuilder) =>
    {
        optionsBuilder.UseSqlServer(options.Configuration.GetConnectionString("SQLServerConnection"));
    });
});

builder.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddDebug();
    logging.AddConsole();
});
var host = builder.Build();
