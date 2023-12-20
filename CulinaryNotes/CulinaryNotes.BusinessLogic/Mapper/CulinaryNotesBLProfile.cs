using AutoMapper;
using CulinaryNotes.BusinessLogic.CulinaryNotes;
//using CulinaryNotes.BusinessLogic.CulinaryNotes.Entities;
using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.Mapper
{
    public class CulinaryNotesBLProfile : Profile
    {
        public CulinaryNotesBLProfile()
        {
            CreateMap<CulinaryNoteEntity, CulinaryNoteModel>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.ExternalId));

            CreateMap<CreateCulinaryNoteModel, CulinaryNoteEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
                .ForMember(dest => dest.IngredientsInCulinaryNote, opt => opt.Ignore());
        }
    }
}
