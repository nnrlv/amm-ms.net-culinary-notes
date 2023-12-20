using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.Users.Entities
{
    public class UserModel
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<CulinaryNoteEntity> CulinaryNotes { get; set; }
        public List<UserRatingEntity> UserRatings { get; set; }
    }
}
