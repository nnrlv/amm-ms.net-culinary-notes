using CulinaryNotes.DataAccess;

namespace CulinaryNotes.WebAPI.Settings
{
    public class CulinaryNotesSettingsReader
    {
        public static CulinaryNotesSettings Read(IConfiguration configuration)
        {
            return new CulinaryNotesSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                CulinaryNotesDbContextConnectionString = configuration.GetValue<string>("CulinaryNotesDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
