using CleanQuestTracker.Backend.Notifications;
using CleanQuestTracker.Backend.Notifications.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension method class for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers email sender to service collections.
    /// </summary>
    /// <param name="serviceCollection">Service collection to which the email sender is added.</param>
    /// <param name="configuration">Configuration containing sections required by email sender implementations.</param>
    /// <returns>Updated service collection.</returns>
    /// <exception cref="Exception">Thrown if namespace full name is null.</exception>
    public static IServiceCollection AddEmailSender(this IServiceCollection serviceCollection, IConfigurationRoot configuration)
    {
        serviceCollection.TryAddScoped<INotificationSender, EmailNotificationSender>();
        serviceCollection.Configure<EmailSenderSettings>(configuration.GetSection(typeof(EmailSenderSettings).FullName 
            ?? throw new Exception($"Incorrect parameter name for class {nameof(EmailSenderSettings)}.")));

        return serviceCollection;
    }
}
