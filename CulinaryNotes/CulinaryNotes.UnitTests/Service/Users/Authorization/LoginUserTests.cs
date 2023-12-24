using CulinaryNotes.BusinessLogic.Auth.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryNotes.UnitTests.Service.Users.Authorization;

public class LoginUserTests : CulinaryNotesServiceTestsBaseClass
{
    [Test]
    public async Task SuccessFullResult()
    {
        var user = new UserEntity()
        {
            Email = "test@test",
            Name = "test",
        };
        var password = "Password1@";

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
        var result = await userManager.CreateAsync(user, password);

        var query = $"?email={user.Email}&password={password}";
        var requestedUri = CulinaryNotesApiEndpoints.AuthorizeUserEndpoint + query;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestedUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        var responseContentJson = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

        content.Should().NotBeNull();
        content.AccessToken.Should().NotBeNull();
        content.RefreshToken.Should().NotBeNull();

        var requestToGetAllCulinaryNotes =
            new HttpRequestMessage(HttpMethod.Get, CulinaryNotesApiEndpoints.GetAllCulinaryNotesEndpoint);

        var clientWithToken = TestHttpClient;
        client.SetBearerToken(content.AccessToken);
        var getAllUsersResponse = await client.SendAsync(requestToGetAllCulinaryNotes);

        getAllUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task BadRequestUserNotFoudResultTest()
    {
        var login = "not_existing@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
        var user = userRepository.GetAll().FirstOrDefault(x => x.Name.ToLower() == login.ToLower());
        if (user != null)
        {
            userRepository.Delete(user);
        }

        var password = "password";

        var query = $"?email={login}&password={password}";
        var requestUri = CulinaryNotesApiEndpoints.AuthorizeUserEndpoint + query;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await TestHttpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task PasswordIsIncorrectResultTest()
    {
        var user = new UserEntity()
        {
            Email = "test@test",
            Name = "test",
        };
        var password = "password";

        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var userManager = scope.ServiceProvider.GetService<UserManager<UserEntity>>();
        await userManager.CreateAsync(user, password);

        var incorrect_password = "kjdfdfsdf";

        var query = $"?email={user.Name}&password={incorrect_password}";
        var requestUri = CulinaryNotesApiEndpoints.AuthorizeUserEndpoint + query;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    [TestCase("", "")]
    [TestCase("qwe", "")]
    [TestCase("test@test", "")]
    [TestCase("", "password")]
    public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
    {
        var query = $"?login={login}&password={password}";
        var requestUri = CulinaryNotesApiEndpoints.AuthorizeUserEndpoint + query;
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
