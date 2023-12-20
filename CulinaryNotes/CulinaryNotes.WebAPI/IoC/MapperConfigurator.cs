using CulinaryNotes.BusinessLogic.Mapper;
using CulinaryNotes.WebAPI.Controllers.Mapper;

namespace CulinaryNotes.WebAPI.IoC;

public class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<CulinaryNotesBLProfile>();
            config.AddProfile<UsersServiceProfile>();
            config.AddProfile<CulinaryNotesServiceProfile>();
        });
    }
}