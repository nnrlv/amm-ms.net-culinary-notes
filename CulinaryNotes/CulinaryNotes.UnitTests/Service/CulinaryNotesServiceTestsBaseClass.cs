using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;
using CulinaryNotes.UnitTests.Service.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using NUnit.Framework;

namespace CulinaryNotes.UnitTests.Service;

public class CulinaryNotesServiceTestsBaseClass
{
    public CulinaryNotesServiceTestsBaseClass()
    {
        var settings = TestSettingsHelper.GetSettings();

        _testServer = new TestWebApplicationFactory(services =>
        {
            services.Replace(ServiceDescriptor.Scoped(_ =>
            {
                var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(TestHttpClient);
                return httpClientFactoryMock.Object;
            }));
            services.PostConfigureAll<JwtBearerOptions>(options =>
            {
                options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{settings.IdentityServerUri}/.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever(),
                    new HttpDocumentRetriever(TestHttpClient)
                    {
                        RequireHttps = false,
                        SendAdditionalHeaderData = true
                    });
            });
        });
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
        var user = userRepository.Save(new UserEntity()
        {
            Email = "test@test",
            Name = "test",
            Surname = "test",
            PasswordHash = "test"
        });
        var categoryRepository = scope.ServiceProvider.GetRequiredService<IRepository<CategoryEntity>>();
        var category = categoryRepository.Save(new CategoryEntity() { Name = "test" });
        var culinaryNoteRepository = scope.ServiceProvider.GetRequiredService<IRepository<CulinaryNoteEntity>>();
        var culinaryNote = culinaryNoteRepository.Save(new CulinaryNoteEntity()
        {
            Name = "test",
            Description = "test",
            Rating = 10,
            UserId = user.Id,
            CategoryId = category.Id
        });
        TestDiaryEntryId = culinaryNote.Id;
    }

    public T? GetService<T>()
    {
        return _testServer.Services.GetRequiredService<T>();
    }

    private readonly WebApplicationFactory<Program> _testServer;
    protected int TestDiaryEntryId;
    protected HttpClient TestHttpClient => _testServer.CreateClient();
}
