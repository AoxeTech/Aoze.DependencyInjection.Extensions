namespace Aoxe.DependencyInjection.Extensions.TestProject;

public class AddScopedUnitTest
{
    [Fact]
    public void AddScopedTest0()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy(typeof(ITest), typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest1()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy(typeof(ITest), _ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest2()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy<ITest, TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest3()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy(typeof(TestClass));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest4()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy<TestClass>();

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<TestClass>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<TestClass>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<TestClass>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest5()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy<ITest>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }

    [Fact]
    public void AddScopedTest6()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddScopedWithLazy<ITest, TestClass>(_ => new TestClass());

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetRequiredService<ITest>();
        Assert.NotNull(service);
        Assert.IsType<TestClass>(service);

        var lazyService = serviceProvider.GetRequiredService<Lazy<ITest>>();
        Assert.NotNull(lazyService);
        Assert.IsType<Lazy<ITest>>(lazyService);
        Assert.IsType<TestClass>(lazyService.Value);
    }
}
