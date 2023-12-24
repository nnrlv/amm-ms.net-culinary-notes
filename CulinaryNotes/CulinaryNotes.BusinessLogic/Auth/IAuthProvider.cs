using CulinaryNotes.BusinessLogic.Auth.Entities;

namespace CulinaryNotes.BusinessLogic.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> AuthorizeUser(string email, string password);
    Task RegisterUser(string email, string password);
}
