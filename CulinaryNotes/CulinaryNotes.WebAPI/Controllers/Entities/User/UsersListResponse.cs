using CulinaryNotes.BusinessLogic.Users.Entities;

namespace CulinaryNotes.WebAPI.Controllers.Entities.User
{
    public class UsersListResponse
    {
        public List<UserModel> Users { get; set; }
    }
}
