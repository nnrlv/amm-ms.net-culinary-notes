using CulinaryNotes.WebAPI.IoC;
using CulinaryNotes.WebAPI.Settings;
using FitnessClub.Service.IoC;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var settings = CulinaryNotesSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

DbContextConfigurator.ConfigureApplication(app);
SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
