using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CulinaryNotes.DataAccess;
using CulinaryNotes.WebAPI.Settings;
using Microsoft.Extensions.Configuration;


namespace CulinaryNotes.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        Settings = CulinaryNotesSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<CulinaryNotesDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<CulinaryNotesDbContext>(
            options => { options.UseSqlServer(Settings.CulinaryNotesDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly CulinaryNotesSettings Settings;
    protected readonly IDbContextFactory<CulinaryNotesDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}