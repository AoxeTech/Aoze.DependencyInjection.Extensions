namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    private static readonly MethodInfo GetServiceGenericMethod =
        typeof(ServiceProviderServiceExtensions)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(method =>
                method.Name == nameof(ServiceProviderServiceExtensions.GetService)
                && method.IsGenericMethod
            );

    private static object AddCreateFunc(IServiceProvider provider, Type serviceType)
    {
        // Create a constant expression for the provider
        var providerParameter = Expression.Constant(provider);

        // Create the generic GetService method for the specific service type
        var getServiceMethod = GetServiceGenericMethod.MakeGenericMethod(serviceType);

        // Build the method call expression: GetService<TService>(provider)
        var callExpression = Expression.Call(getServiceMethod, providerParameter);

        // Create a lambda expression of type Func<TService>
        var lambdaType = typeof(Func<>).MakeGenericType(serviceType);
        var lambda = Expression.Lambda(lambdaType, callExpression);

        // Compile the lambda expression to create a delegate
        var func = lambda.Compile();
        return func;
    }
}
