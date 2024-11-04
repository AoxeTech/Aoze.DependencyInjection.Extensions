namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds a transient service of the type specified in <paramref name="serviceType"/> with an
    /// implementation of the type specified in <paramref name="implementationType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationType">The implementation type of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType
    ) =>
        services
            .AddTransient(serviceType, implementationType)
            .AddTransient(
                typeof(Lazy<>).MakeGenericType(serviceType),
                typeof(Lazy<>).MakeGenericType(implementationType)
            );

    /// <summary>
    /// Adds a transient service of the type specified in <paramref name="serviceType"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy(
        this IServiceCollection services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory
    ) =>
        services
            .AddTransient(serviceType, implementationFactory)
            .AddTransient(
                typeof(Lazy<>).MakeGenericType(serviceType),
                provider => new Lazy<object>(() => implementationFactory(provider))
            );

    /// <summary>
    /// Adds a transient service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy<TService, TImplementation>(
        this IServiceCollection services
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddTransient<TService, TImplementation>()
            .AddTransient<Lazy<TService>>(provider => new Lazy<TService>(
                () => ActivatorUtilities.CreateInstance<TImplementation>(provider)
            ));

    /// <summary>
    /// Adds a transient service of the type specified in <paramref name="serviceType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy(
        this IServiceCollection services,
        Type serviceType
    ) =>
        services
            .AddTransient(serviceType)
            .AddTransient(typeof(Lazy<>).MakeGenericType(serviceType));

    /// <summary>
    /// Adds a transient service of the type specified in <typeparamref name="TService"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy<TService>(
        this IServiceCollection services
    )
        where TService : class => services.AddTransient<TService>().AddTransient<Lazy<TService>>();

    /// <summary>
    /// Adds a transient service of the type specified in <typeparamref name="TService"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Transient"/>
    public static IServiceCollection AddTransientWithLazy<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory
    )
        where TService : class =>
        services
            .AddTransient(implementationFactory)
            .AddTransient<Lazy<TService>>(provider => new Lazy<TService>(
                () => implementationFactory(provider)
            ));

    /// <summary>
    /// Adds a transient service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation" /> using the
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddTransientWithLazy<TService, TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddTransient<TService, TImplementation>(implementationFactory)
            .AddTransient<Lazy<TService>>(provider => new Lazy<TService>(
                () => implementationFactory(provider)
            ));
}
