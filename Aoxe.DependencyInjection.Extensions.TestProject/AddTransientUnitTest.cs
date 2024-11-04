namespace Aoxe.DependencyInjection.Extensions.TestProject;

public class AddTransientUnitTest
{
    [Fact]
    public void AddTransientTest0()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy(typeof(ITest), typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest1()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy(typeof(ITest), _ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest2()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy<ITest, TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest3()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy(typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest4()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy<TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest5()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy<ITest>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }

    [Fact]
    public void AddTransientTest6()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransientWithLazy<ITest, TestClass>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.NotEqual(service, lazyService.Value);
    }
}
