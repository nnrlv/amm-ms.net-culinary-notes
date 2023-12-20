using AutoMapper;
//using CulinaryNotes.BusinessLogic.CulinaryNotes.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class CulinaryNotesProvider : ICulinaryNotesProvider
    {
        private readonly IRepository<CulinaryNoteEntity> _repository;
        private readonly IMapper _mapper;

        public CulinaryNotesProvider(IRepository<CulinaryNoteEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CulinaryNoteModel> GetCulinaryNotes(CulinaryNoteModelFilter? filter = null)
        {
            var name = filter?.Name;
            var description = filter?.Description;
            var instructions = filter?.Instructions;
            var rating = filter?.Rating;
            var userId = filter?.UserId;
            var categoryId = filter?.CategoryId;

            var culinaryNotes = _repository.GetAll(x =>
            (name == null || x.Name == name) &&
            (description == null || x.Description == description) &&
            (instructions == null || x.Instructions == instructions) &&
            (rating == null || x.Rating == rating) &&
            (categoryId == null || x.CategoryId == categoryId) &&
            (userId == null || x.UserId == userId));

            return _mapper.Map<IEnumerable<CulinaryNoteModel>>(culinaryNotes);
        }

        public CulinaryNoteModel GetCulinaryNoteInfo(Guid id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
            {
                throw new ArgumentException("Culinary note not found");
            }

            return _mapper.Map<CulinaryNoteModel>(entity);
        }

    }
}
