namespace CulinaryNotes.BusinessLogic.Users.Entities
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<int> CulinaryNotesIds { get; set; }
        public List<int> UserRatingsIds { get; set; }
    }
}
