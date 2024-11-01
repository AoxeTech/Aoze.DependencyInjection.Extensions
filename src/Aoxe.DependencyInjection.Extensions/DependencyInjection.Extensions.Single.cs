using Microsoft.Extensions.DependencyInjection;

namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType" /> with an
    /// implementation of the type specified in <paramref name="implementationType" /> to the
    /// specified <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationType">The implementation type of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="F:Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType
    )
    {
        services.AddSingleton(serviceType, implementationType);
        services.AddSingleton(
            typeof(Lazy<>).MakeGenericType(serviceType),
            serviceProvider =>
                Activator.CreateInstance(
                    typeof(Lazy<>).MakeGenericType(serviceType),
                    new Func<object>(() => serviceProvider.GetRequiredService(serviceType))
                )!
        );
        return services;
    }
    
    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType" /> with a
    /// factory specified in <paramref name="implementationFactory" /> to the
    /// specified <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="F:Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingleton(
        this IServiceCollection services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
}
