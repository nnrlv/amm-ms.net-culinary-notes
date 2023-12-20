using AutoMapper;
using CulinaryNotes.BusinessLogic.Users.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IRepository<CulinaryNoteEntity> _culinaryNotesRepository;
        private readonly IRepository<UserRatingEntity> _userRatingsRepository;
        private readonly IMapper _mapper;

        public UsersManager(IRepository<UserEntity> repository, IRepository<CulinaryNoteEntity> culinaryNotesRepository,
            IRepository<UserRatingEntity> userRatingsRepository, IMapper mapper)
        {
            _repository = repository;
            _culinaryNotesRepository = culinaryNotesRepository;
            _userRatingsRepository = userRatingsRepository;
            _mapper = mapper;
        }

        public UserModel CreateUser(CreateUserModel model)
        {

            var entity = _mapper.Map<UserEntity>(model);

            if (model.CulinaryNotesIds != null && model.CulinaryNotesIds.Any())
            {
                var culinaryNotes = _culinaryNotesRepository.GetAll(d => model.CulinaryNotesIds.Contains(d.Id)).ToList();
                foreach (var culinaryNote in culinaryNotes)
                {
                    entity.CulinaryNotes.Add(culinaryNote);
                }
            }

            if (model.UserRatingsIds != null && model.UserRatingsIds.Any())
            {
                var userRatings = _userRatingsRepository.GetAll(d => model.UserRatingsIds.Contains(d.Id)).ToList();
                foreach (var userRating in userRatings)
                {
                    entity.UserRatings.Add(userRating);
                }
            }

            _repository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }

        public void DeleteUser(Guid id)
        {
            var entity = _repository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("User not found");
            }

            _repository.Delete(entity);
        }

        public UserModel UpdateUser(Guid id, UpdateUserModel model)
        {
            var entity = _repository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("User not found");
            }


            entity.Name = model.Name;
            entity.Surname = model.Surname;
            entity.Email = model.Email;

            entity.CulinaryNotes.Clear();
            if (model.CulinaryNotesIds != null && model.CulinaryNotesIds.Any())
            {
                var culinaryNotes = _culinaryNotesRepository.GetAll(d => model.CulinaryNotesIds.Contains(d.Id)).ToList();
                foreach (var culinaryNote in culinaryNotes)
                {
                    entity.CulinaryNotes.Add(culinaryNote);
                }
            }

            entity.UserRatings.Clear();
            if (model.UserRatingsIds != null && model.UserRatingsIds.Any())
            {
                var userRatings = _userRatingsRepository.GetAll(d => model.UserRatingsIds.Contains(d.Id)).ToList();
                foreach (var userRating in userRatings)
                {
                    entity.UserRatings.Add(userRating);
                }
            }

            _repository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }

    }
}
