using CulinaryNotes.DataAccess;

namespace CulinaryNotes.WebAPI.Settings
{
    public class CulinaryNotesSettingsReader
    {
        public static CulinaryNotesSettings Read(IConfiguration configuration)
        {
            return new CulinaryNotesSettings()
            {
                CulinaryNotesDbContextConnectionString = configuration.GetValue<string>("CulinaryNotesDbContext")
            };
        }
    }
}
