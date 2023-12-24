using Microsoft.Extensions.Configuration;

namespace CulinaryNotes.UnitTests.Service.Helpers;

public class ConfigurationHelper
{
    public static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
    }
}
