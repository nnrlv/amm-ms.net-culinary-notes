using CulinaryNotes.WebAPI.Settings;

namespace CulinaryNotes.UnitTests.Service.Helpers;

public class TestSettingsHelper
{
    public static CulinaryNotesSettings GetSettings()
    {
        return CulinaryNotesSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}
