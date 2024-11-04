namespace Aoxe.DependencyInjection.Extensions.TestProject;

public class AddSingleUnitTest
{
    [Fact]
    public void AddSingleTest0()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy(typeof(ITest), typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest1()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy(typeof(ITest), _ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest2()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy<ITest, TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest3()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy(typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest4()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy<TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest5()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy<ITest>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest6()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy<ITest, TestClass>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest7()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy(typeof(ITest), new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }

    [Fact]
    public void AddSingleTest8()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingletonWithLazy<ITest>(new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
        
        Assert.Equal(service, lazyService.Value);
    }
}
