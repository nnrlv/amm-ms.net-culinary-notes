using AutoMapper;
//using CulinaryNotes.BusinessLogic.CulinaryNotes.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class CulinaryNoteManager : ICulinaryNoteManager
    {
        private readonly IRepository<CulinaryNoteEntity> _repository;
        private readonly IRepository<UserRatingEntity> _userRatingsRepository;
        private readonly IRepository<IngredientInCulinaryNoteEntity> _ingredientsInCulinaryNoteRepository;
        private readonly IMapper _mapper;

        public CulinaryNoteManager(IRepository<CulinaryNoteEntity> repository, IRepository<UserRatingEntity> userRatingsRepository,
            IRepository<IngredientInCulinaryNoteEntity> ingredientsInCulinaryNoteRepository, IMapper mapper)
        {
            _repository = repository;
            _userRatingsRepository = userRatingsRepository;
            _ingredientsInCulinaryNoteRepository = ingredientsInCulinaryNoteRepository;
            _mapper = mapper;
        }

        public CulinaryNoteModel CreateCulinaryNote(CreateCulinaryNoteModel model)
        {

            var entity = _mapper.Map<CulinaryNoteEntity>(model);

            if (model.UserRatingsIds != null && model.UserRatingsIds.Any())
            {
                var userRatings = _userRatingsRepository.GetAll(d => model.UserRatingsIds.Contains(d.Id)).ToList();
                foreach (var userRating in userRatings)
                {
                    entity.UserRatings.Add(userRating);
                }
            }

            if (model.IngredientsInCulinaryNoteIds != null && model.IngredientsInCulinaryNoteIds.Any())
            {
                var ingredients = _ingredientsInCulinaryNoteRepository
                    .GetAll(d => model.IngredientsInCulinaryNoteIds.Contains(d.Id)).ToList();
                foreach (var ingredient in ingredients)
                {
                    entity.IngredientsInCulinaryNote.Add(ingredient);
                }
            }

            _repository.Save(entity);

            return _mapper.Map<CulinaryNoteModel>(entity);
        }

        public void DeleteCulinaryNote(Guid id)
        {
            var entity = _repository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("CulinaryNote not found");
            }

            _repository.Delete(entity);
        }

        public CulinaryNoteModel UpdateCulinaryNote(Guid id, UpdateCulinaryNoteModel model)
        {
            var entity = _repository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("CulinaryNote not found");
            }

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Instructions = model.Instructions;
            entity.Rating = model.Rating;

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

            return _mapper.Map<CulinaryNoteModel>(entity);
        }

    }
}
