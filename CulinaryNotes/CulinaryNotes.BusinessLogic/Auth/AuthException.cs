namespace CulinaryNotes.BusinessLogic.Auth
{
    public enum Error
    {
        UserNotFound,
        LoginOrPasswordIsIncorrect,
        DiscoveryDocumentError,
        TokenRequestError,
        CreationUserError
    }

    public class AuthException : Exception
    {
        public Error ErrorCode { get; }

        public AuthException(string message, Error errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }

    public class UserNotFoundException : AuthException
    {
        public UserNotFoundException(string message) : base(message, Error.UserNotFound) { }
    }

    public class LoginOrPasswordInIncorrectException : AuthException
    {
        public LoginOrPasswordInIncorrectException(string message) : base(message, Error.LoginOrPasswordIsIncorrect) { }
    }

    public class DiscoveryDocumentException : AuthException
    {
        public DiscoveryDocumentException(string message) : base(message, Error.DiscoveryDocumentError) { }
    }

    public class TokenRequestException : AuthException
    {
        public TokenRequestException(string message) : base(message, Error.TokenRequestError) { }
    }

    public class UserCreationException : AuthException
    {
        public UserCreationException(string message) : base(message, Error.CreationUserError) { }
    }
}
