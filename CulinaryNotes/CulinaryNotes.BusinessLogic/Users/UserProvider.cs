using AutoMapper;
using CulinaryNotes.BusinessLogic.Users.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.Users
{
    public class UserProvider : IUserProvider
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserProvider(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetUsers(UserModelFilter? filter = null)
        {
            var name = filter?.Name;
            var surname = filter?.Surname;
            var email = filter?.Email;

            var users = _repository.GetAll(x =>
                (name == null || x.Name == name) &&
                (surname == null || x.Surname == surname) &&
                (email == null || x.Email == email));

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public UserModel GetUserInfo(Guid id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
            {
                throw new ArgumentException("User not found");
            }

            return _mapper.Map<UserModel>(entity);
        }

    }
}
