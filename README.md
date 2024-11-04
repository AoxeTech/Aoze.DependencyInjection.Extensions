# Aoxe.DependencyInjection.Extensions

Aoxe.DependencyInjection.Extensions provides extension methods for Microsoft's Dependency Injection container to simplify service registration with Lazy\<T\> support. These extensions allow for deferred instantiation of services, improving performance by delaying object creation until it's actually needed.

## Features

- Extension methods to register services with Lazy\<T\>
  - AddSingletonWithLazy
  - AddScopedWithLazy
  - AddTransientWithLazy
- Support for both type and factory-based registrations
- Simplifies the use of Lazy\<T\> in dependency injection scenarios

## Installation

To install the package, add the following to your project file:

```xml
<PackageReference Include="Aoxe.DependencyInjection.Extensions" Version="2024.1.0" />
```

Or use the .NET CLI:

```bash
dotnet add package Aoxe.DependencyInjection.Extensions
```

## Usage

First, include the namespace:

```csharp
using Aoxe.DependencyInjection.Extensions;
```

### Registering Services

#### Singleton Services

Use the 'AddSingletonWithLazy' method to register singleton services with Lazy\<T\> support:

```csharp
services.AddSingletonWithLazy<IMyService, MyServiceImplementation>();
```

#### Scoped Services

For scoped services, use the 'AddScopedWithLazy' method:

```csharp
services.AddScopedWithLazy<IMyService, MyServiceImplementation>();
```

#### Transient Services

For transient services, use the 'AddTransientWithLazy' method:

```csharp
services.AddTransientWithLazy<IMyService, MyServiceImplementation>();
```

### Accessing Services

Inject Lazy\<T\> into your classes to defer service instantiation:

```csharp
public class MyController
{
    private readonly Lazy<IMyService> _myService;

    public MyController(Lazy<IMyService> myService)
    {
        _myService = myService;
    }

    public void DoWork()
    {
        // The IMyService instance is created only when accessed
        _myService.Value.PerformOperation();
    }
}
```

## Examples

Refer to the unit tests for more examples:

- AddSingletonUnitTest.cs
- AddScopedUnitTest.cs
- AddTransientUnitTest.cs

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Please submit issues or pull requests to the [GitHub repository](https://github.com/AoxeTech/Aoxe.DependencyInjection.Extensions).

---

Thank`s for [JetBrains](https://www.jetbrains.com/) for the great support in providing assistance and user-friendly environment for my open source projects.

[![JetBrains](https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg?_gl=1*f25lxa*_ga*MzI3ODk2MjY0LjE2NzA0NjY4MDQ.*_ga_9J976DJZ68*MTY4OTY4NzY5OS4zNC4xLjE2ODk2ODgwMDAuNTMuMC4w)](https://www.jetbrains.com/community/opensource/#support)
