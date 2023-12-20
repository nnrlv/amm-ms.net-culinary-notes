using CulinaryNotes.BusinessLogic.Users.Entities;

namespace CulinaryNotes.BusinessLogic.Users
{
    public interface IUserProvider
    {
        IEnumerable<UserModel> GetUsers(UserModelFilter filter = null);
        UserModel GetUserInfo(Guid id);
    }
}
