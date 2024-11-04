namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType"/> with an
    /// implementation of the type specified in <paramref name="implementationType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationType">The implementation type of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType
    )
    {
        services.AddSingleton(serviceType, implementationType);
        var lazyServiceType = typeof(Lazy<>).MakeGenericType(serviceType);
        return services.AddSingleton(
            lazyServiceType,
            provider =>
            {
                // Create a Func<TService> that calls provider.GetService<TService>()
                var func = CreateFunc(provider, serviceType);

                // Create an instance of Lazy<TService> with the Func<TService>
                return Activator.CreateInstance(lazyServiceType, func)!;
            }
        );
    }

    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory
    )
    {
        services.AddSingleton(serviceType, implementationFactory);
        var lazyServiceType = typeof(Lazy<>).MakeGenericType(serviceType);
        return services.AddSingleton(
            lazyServiceType,
            provider =>
            {
                // Create a Func<TService> that calls provider.GetService<TService>()
                var func = CreateFunc(provider, serviceType);

                // Create an instance of Lazy<TService> with the Func<TService>
                return Activator.CreateInstance(lazyServiceType, func)!;
            }
        );
    }

    /// <summary>
    /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy<TService, TImplementation>(
        this IServiceCollection services
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddSingleton<TService, TImplementation>()
            .AddSingleton<Lazy<TService>>(
                provider => new Lazy<TService>(provider.GetRequiredService<TService>)
            );

    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType
    ) =>
        services
            .AddSingleton(serviceType)
            .AddSingleton(typeof(Lazy<>).MakeGenericType(serviceType));

    /// <summary>
    /// Adds a singleton service of the type specified in <typeparamref name="TService"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services
    )
        where TService : class => services.AddSingleton<TService>().AddSingleton<Lazy<TService>>();

    /// <summary>
    /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory
    )
        where TService : class =>
        services
            .AddSingleton(implementationFactory)
            .AddSingleton<Lazy<TService>>(
                provider => new Lazy<TService>(provider.GetRequiredService<TService>)
            );

    /// <summary>
    /// Adds a singleton service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation" /> using the
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy<TService, TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddSingleton<TService, TImplementation>(implementationFactory)
            .AddSingleton<Lazy<TService>>(
                provider => new Lazy<TService>(provider.GetRequiredService<TService>)
            );

    /// <summary>
    /// Adds a singleton service of the type specified in <paramref name="serviceType"/> with an
    /// instance specified in <paramref name="implementationInstance"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationInstance">The instance of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy(
        this IServiceCollection services,
        Type serviceType,
        object implementationInstance
    )
    {
        services.AddSingleton(serviceType, implementationInstance);

        // Create Lazy<T> type
        var lazyServiceType = typeof(Lazy<>).MakeGenericType(serviceType);

        // Create Func<T> type
        var funcType = typeof(Func<>).MakeGenericType(serviceType);

        // Create expression () => (T)implementationInstance
        var instanceExpression = Expression.Constant(implementationInstance, serviceType);
        var lambda = Expression.Lambda(funcType, instanceExpression);
        var func = lambda.Compile();

        // Create Lazy<T> instance with the Func<T>
        var lazyInstance = Activator.CreateInstance(lazyServiceType, func);

        // Register Lazy<T> singleton
        services.AddSingleton(lazyServiceType, lazyInstance!);

        return services;
    }

    /// <summary>
    /// Adds a singleton service of the type specified in <typeparamref name="TService" /> with an
    /// instance specified in <paramref name="implementationInstance"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationInstance">The instance of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Singleton"/>
    public static IServiceCollection AddSingletonWithLazy<TService>(
        this IServiceCollection services,
        TService implementationInstance
    )
        where TService : class =>
        services
            .AddSingleton(implementationInstance)
            .AddSingleton(new Lazy<TService>(() => implementationInstance));
}
