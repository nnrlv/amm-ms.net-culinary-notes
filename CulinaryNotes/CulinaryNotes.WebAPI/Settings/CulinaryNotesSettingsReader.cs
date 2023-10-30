namespace CulinaryNotes.WebAPI.Settings
{
    public class CulinaryNotesSettingsReader
    {
        public static CulinaryNotesSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new CulinaryNotesSettings();
        }
    }
}
