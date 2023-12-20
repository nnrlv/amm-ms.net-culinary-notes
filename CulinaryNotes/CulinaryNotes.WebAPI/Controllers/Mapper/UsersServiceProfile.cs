using AutoMapper;
using CulinaryNotes.BusinessLogic.Users.Entities;
using CulinaryNotes.BusinessLogic.Users;
using CulinaryNotes.WebAPI.Controllers.Entities.User;

namespace CulinaryNotes.WebAPI.Controllers.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile()
        {
            CreateMap<UsersFilter, UserModelFilter>();
            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<UpdateUserRequest, UpdateUserModel>();
        }
    }
}
