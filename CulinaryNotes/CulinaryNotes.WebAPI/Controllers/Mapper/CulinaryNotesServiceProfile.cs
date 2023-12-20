using AutoMapper;
using CulinaryNotes.BusinessLogic.CulinaryNotes;
using CulinaryNotes.WebAPI.Controllers.Entities.CulinaryNote;

namespace CulinaryNotes.WebAPI.Controllers.Mapper
{
    public class CulinaryNotesServiceProfile : Profile
    {
        public CulinaryNotesServiceProfile()
        {
            CreateMap<CulinaryNotesFilter, CulinaryNoteModelFilter>();
            CreateMap<CreateCulinaryNoteRequest, CreateCulinaryNoteModel>();
            CreateMap<UpdateCulinaryNoteRequest, UpdateCulinaryNoteModel>();
        }
    }
}
