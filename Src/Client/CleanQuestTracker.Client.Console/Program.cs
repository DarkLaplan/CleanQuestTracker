using CleanQuestTracker.Backend.Notifications;
using CleanQuestTracker.Backend.Notifications.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

// DI services registration.
await AppStartup();

// Load data from database


// Create notifications based on data.


// Send notifications


Console.WriteLine("Hello, World!");

async Task AppStartup()
{
    var builder = new ConfigurationBuilder();
    BuildConfiguration(builder);

    var configuration = builder.Build();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

    using IHost hostBuilder = Host.CreateDefaultBuilder()
        .UseDefaultServiceProvider((context, options) =>
        {
            options.ValidateOnBuild = false;
        })
        .ConfigureServices((context, services) =>
        {
            services.AddEmailSender(configuration);
        })
        .UseSerilog()
        .Build();

    var notificationSender = ActivatorUtilities.GetServiceOrCreateInstance<INotificationSender>(hostBuilder.Services);

    var testNotification = new Notification
    {
        Message = "Kokote trva ti to dlouho.",
        NotificationType = "Error notification kvuli setreni podlahy.",
        User = new User
        {
            Email = "Lansky.michal3@gmail.com",
            Name = "Michal"
        }
    };

    await notificationSender.SendNotificationAsync(testNotification);
    await hostBuilder.RunAsync();
}

void BuildConfiguration(IConfigurationBuilder configurationBuilder)
{
    var enviroment = Environment.GetEnvironmentVariable("DOTNET_ENVIROMENT");
    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
        .AddUserSecrets<Program>()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Add dev enviroment json file.
        .AddEnvironmentVariables();
}