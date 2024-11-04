namespace Aoxe.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    private static object CreateFunc(IServiceProvider provider, Type serviceType)
    {
        // Expression: () => provider.GetService<TService>()
        var providerParameter = Expression.Constant(provider);

        // Get the generic method IServiceProvider.GetService<T>()
        var getServiceMethod = typeof(ServiceProviderServiceExtensions)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .First(
                methodInfo =>
                    methodInfo
                        is {
                            Name: nameof(ServiceProviderServiceExtensions.GetService),
                            IsGenericMethod: true
                        }
                    && methodInfo.GetParameters().Length == 1
            )
            .MakeGenericMethod(serviceType);

        // Build the method call expression
        var callExpression = Expression.Call(getServiceMethod, providerParameter);

        // Create a lambda expression of type Func<TService>
        var lambdaType = typeof(Func<>).MakeGenericType(serviceType);
        var lambda = Expression.Lambda(lambdaType, callExpression);

        // Compile the lambda expression to create a delegate
        var func = lambda.Compile();
        return func;
    }
}
