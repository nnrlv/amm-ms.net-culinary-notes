namespace CulinaryNotes.WebAPI.Settings
{
    public class CulinaryNotesSettings
    {
        public Uri? ServiceUri { get; set; }
        public string? CulinaryNotesDbContextConnectionString { get; set; }
        public string? IdentityServerUri { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
