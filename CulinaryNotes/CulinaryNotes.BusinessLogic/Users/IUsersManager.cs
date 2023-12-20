using CulinaryNotes.BusinessLogic.Users.Entities;

namespace CulinaryNotes.BusinessLogic.Users
{
    public interface IUsersManager
    {
        UserModel CreateUser(CreateUserModel model);
        void DeleteUser(Guid id);
        UserModel UpdateUser(Guid id, UpdateUserModel model);
    }
}
