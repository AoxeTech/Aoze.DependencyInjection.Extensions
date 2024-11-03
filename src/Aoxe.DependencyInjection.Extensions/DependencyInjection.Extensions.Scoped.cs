namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    //
    // Summary:
    //     Adds a scoped service of the type specified in serviceType with an implementation
    //     of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationType:
    //     The implementation type of the service.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType
    ) =>
        services
            .AddScoped(serviceType, implementationType)
            .AddScoped(
                typeof(Lazy<>).MakeGenericType(serviceType),
                typeof(Lazy<>).MakeGenericType(implementationType)
            );

    //
    // Summary:
    //     Adds a scoped service of the type specified in serviceType with a factory
    //     specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory
    ) =>
        services
            .AddScoped(serviceType, implementationFactory)
            .AddScoped(
                typeof(Lazy<>).MakeGenericType(serviceType),
                provider => new Lazy<object>(() => implementationFactory(provider))
            );

    //
    // Summary:
    //     Adds a scoped service of the type specified in TService with an implementation
    //     type specified in TImplementation using the factory specified in implementationFactory
    //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // Type parameters:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy<TService, TImplementation>(
        this IServiceCollection services
    )
        where TService : class
        where TImplementation : class, TService =>
        // services
        //     .AddScoped<TService, TImplementation>()
        //     .AddScoped<Lazy<TService>>(
        //         provider =>
        //             new Lazy<TService>(
        //                 () => ActivatorUtilities.CreateInstance<TImplementation>(provider)
        //             )
        //     );
        services
            .AddScoped<TService, TImplementation>()
            .AddScoped<Lazy<TService>>(
                provider =>
                    new Lazy<TService>(
                        () => ActivatorUtilities.CreateInstance<TImplementation>(provider)
                    )
            );

    //
    // Summary:
    //     Adds a scoped service of the type specified in serviceType to the specified
    //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   serviceType:
    //     The type of the service to register and the implementation to use.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy(
        this IServiceCollection services,
        Type serviceType
    ) => services.AddScoped(serviceType).AddScoped(typeof(Lazy<>).MakeGenericType(serviceType));

    //
    // Summary:
    //     Adds a scoped service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    // Type parameters:
    //   TService:
    //     The type of the service to add.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy<TService>(this IServiceCollection services)
        where TService : class => services.AddScoped<TService>().AddScoped<Lazy<TService>>();

    //
    // Summary:
    //     Adds a scoped service of the type specified in TService with a factory specified
    //     in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // Type parameters:
    //   TService:
    //     The type of the service to add.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory
    )
        where TService : class =>
        services
            .AddScoped(implementationFactory)
            .AddScoped<Lazy<TService>>(
                provider => new Lazy<TService>(() => implementationFactory(provider))
            );

    //
    // Summary:
    //     Adds a scoped service of the type specified in TService with an implementation
    //     type specified in TImplementation using the factory specified in implementationFactory
    //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // Type parameters:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddScopedWithLazy<TService, TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddScoped<TService, TImplementation>()
            .AddScoped<Lazy<TService>>(
                provider => new Lazy<TService>(() => implementationFactory(provider))
            );
}
