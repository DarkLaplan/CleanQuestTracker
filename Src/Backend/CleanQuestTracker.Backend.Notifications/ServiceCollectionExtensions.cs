﻿using CleanQuestTracker.Backend.Notifications;
using CleanQuestTracker.Backend.Notifications.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEmailSender(this IServiceCollection serviceCollection, IConfigurationRoot configuration)
    {
        serviceCollection.TryAddScoped<INotificationSender, EmailNotificationSender>();

        var test = typeof(EmailSenderSettings).FullName;
        serviceCollection.Configure<EmailSenderSettings>(configuration.GetSection(test));
        return serviceCollection;
    }
}
