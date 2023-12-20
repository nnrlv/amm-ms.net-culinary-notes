using AutoMapper;
using CulinaryNotes.BusinessLogic.Users.Entities;
using CulinaryNotes.DataAccess.Entities;


namespace CulinaryNotes.BusinessLogic.Mapper
{
    public class UsersBLProfile : Profile
    {
        public UsersBLProfile()
        {
            CreateMap<UserEntity, UserModel>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.ExternalId));

            CreateMap<CreateUserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
                .ForMember(dest => dest.CulinaryNotes, opt => opt.Ignore());
        }
    }
}
