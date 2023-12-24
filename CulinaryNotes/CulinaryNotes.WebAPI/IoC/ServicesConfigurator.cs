using AutoMapper;
using CulinaryNotes.BusinessLogic.Auth;
using CulinaryNotes.BusinessLogic.Users;
using CulinaryNotes.DataAccess.Entities;
using CulinaryNotes.DataAccess;
using Microsoft.AspNetCore.Identity;
using CulinaryNotes.BusinessLogic.CulinaryNotes;
using CulinaryNotes.WebAPI.Settings;

namespace CulinaryNotes.WebAPI.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, CulinaryNotesSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUsersProvider>(x =>
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>()));
        services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        services.AddScoped<IUsersManager, UsersManager>();
        services.AddScoped<ICulinaryNotesManager, CulinaryNotesManager>();
    }
}
