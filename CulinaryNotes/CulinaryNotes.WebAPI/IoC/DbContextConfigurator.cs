using CulinaryNotes.DataAccess;
using CulinaryNotes.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, CulinaryNotesSettings settings)
    {
        services.AddDbContextFactory<CulinaryNotesDbContext>(
            options => { options.UseSqlServer(settings.CulinaryNotesDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<CulinaryNotesDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}