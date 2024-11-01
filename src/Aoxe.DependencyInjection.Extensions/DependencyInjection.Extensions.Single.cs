namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    //
    // Summary:
    //     Adds a singleton service of the type specified in serviceType with an implementation
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
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType
    ) =>
        services
            .AddSingleton(serviceType, implementationType)
            .AddSingleton(
                typeof(Lazy<>).MakeGenericType(serviceType),
                typeof(Lazy<>).MakeGenericType(implementationType)
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in serviceType with a factory
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
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory
    ) =>
        services
            .AddSingleton(serviceType, implementationFactory)
            .AddSingleton(
                typeof(Lazy<>).MakeGenericType(serviceType),
                provider => new Lazy<object>(() => implementationFactory(provider))
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in TService with an implementation
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
    public static IServiceCollection AddSingletonWithLazy<TService, TImplementation>(
        this IServiceCollection services
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddSingleton<TService, TImplementation>()
            .AddSingleton<Lazy<TService>>(
                provider =>
                    new Lazy<TService>(
                        () => ActivatorUtilities.CreateInstance<TImplementation>(provider)
                    )
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in serviceType to the specified
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
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType
    ) =>
        services
            .AddSingleton(serviceType)
            .AddSingleton(typeof(Lazy<>).MakeGenericType(serviceType));

    //
    // Summary:
    //     Adds a singleton service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
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
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services
    )
        where TService : class => services.AddSingleton<TService>().AddSingleton<Lazy<TService>>();

    //
    // Summary:
    //     Adds a singleton service of the type specified in TService with a factory specified
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
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory
    )
        where TService : class =>
        services
            .AddSingleton(implementationFactory)
            .AddSingleton<Lazy<TService>>(
                provider => new Lazy<TService>(() => implementationFactory(provider))
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in TService with an implementation
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
    public static IServiceCollection AddSingletonWithLazy<TService, TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddSingleton<TService, TImplementation>()
            .AddSingleton<Lazy<TService>>(
                provider => new Lazy<TService>(() => implementationFactory(provider))
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in serviceType with an instance
    //     specified in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
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
    //   implementationInstance:
    //     The instance of the service.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        object implementationInstance
    ) =>
        services
            .AddSingleton(serviceType, implementationInstance)
            .AddSingleton(
                typeof(Lazy<>).MakeGenericType(serviceType),
                new Lazy<object>(() => implementationInstance)
            );

    //
    // Summary:
    //     Adds a singleton service of the type specified in TService with an instance specified
    //     in implementationInstance to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service
    //     to.
    //
    //   implementationInstance:
    //     The instance of the service.
    //
    // Returns:
    //     A reference to this instance after the operation has completed.
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services,
        TService implementationInstance
    )
        where TService : class =>
        services
            .AddSingleton(implementationInstance)
            .AddSingleton(new Lazy<TService>(() => implementationInstance));
}
