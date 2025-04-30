using Avalonia.Platform.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaPdmFileViewer.Extensions;

/// <summary>
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddStorageProvider(this IServiceCollection serviceCollection, IStorageProvider storageProvider)
    {
        serviceCollection.AddSingleton(storageProvider);
    }
}