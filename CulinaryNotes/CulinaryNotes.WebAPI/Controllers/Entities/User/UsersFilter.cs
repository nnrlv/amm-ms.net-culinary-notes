using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.WebAPI.Controllers.Entities.User
{
    public class UsersFilter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<int> CulinaryNotesIds { get; set; }
        public List<int> UserRatingsIds { get; set; }
    }
}
