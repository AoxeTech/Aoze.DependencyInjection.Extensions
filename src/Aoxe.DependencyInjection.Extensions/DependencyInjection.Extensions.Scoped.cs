namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds a scoped service of the type specified in <paramref name="serviceType"/> with an
    /// implementation of the type specified in <paramref name="implementationType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationType">The implementation type of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
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

    /// <summary>
    /// Adds a scoped service of the type specified in <paramref name="serviceType"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
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

    /// <summary>
    /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
    public static IServiceCollection AddScopedWithLazy<TService, TImplementation>(
        this IServiceCollection services
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddScoped<TService, TImplementation>()
            .AddScoped<Lazy<TService>>(provider => new Lazy<TService>(
                () => ActivatorUtilities.CreateInstance<TImplementation>(provider)
            ));

    /// <summary>
    /// Adds a scoped service of the type specified in <paramref name="serviceType"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
    public static IServiceCollection AddScopedWithLazy(
        this IServiceCollection services,
        Type serviceType
    ) => services.AddScoped(serviceType).AddScoped(typeof(Lazy<>).MakeGenericType(serviceType));

    /// <summary>
    /// Adds a scoped service of the type specified in <typeparamref name="TService"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
    public static IServiceCollection AddScopedWithLazy<TService>(this IServiceCollection services)
        where TService : class => services.AddScoped<TService>().AddScoped<Lazy<TService>>();

    /// <summary>
    /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with a
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
    public static IServiceCollection AddScopedWithLazy<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory
    )
        where TService : class =>
        services
            .AddScoped(implementationFactory)
            .AddScoped<Lazy<TService>>(provider => new Lazy<TService>(
                () => implementationFactory(provider)
            ));

    /// <summary>
    /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with an
    /// implementation type specified in <typeparamref name="TImplementation" /> using the
    /// factory specified in <paramref name="implementationFactory"/> to the
    /// specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <seealso cref="ServiceLifetime.Scoped"/>
    public static IServiceCollection AddScopedWithLazy<TService, TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory
    )
        where TService : class
        where TImplementation : class, TService =>
        services
            .AddScoped<TService, TImplementation>(implementationFactory)
            .AddScoped<Lazy<TService>>(provider => new Lazy<TService>(
                () => implementationFactory(provider)
            ));
}
