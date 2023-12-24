using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace CulinaryNotes.UnitTests.Service;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly Action<IServiceCollection>? _overrideDependecies;

    public TestWebApplicationFactory(Action<IServiceCollection>? overrideDependecies = null)
    {
        _overrideDependecies = overrideDependecies;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => _overrideDependecies?.Invoke(services));
    }
}
