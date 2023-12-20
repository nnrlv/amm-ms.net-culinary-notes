using AutoMapper;
using CulinaryNotes.WebAPI.Controllers.Mapper;

namespace CulinaryNotes.UnitTests.BusinessLogic.Users
{
    public class UserProviderMapperHelper
    {
        public static IMapper Mapper { get; }

        static UserProviderMapperHelper()
        {
            var config = new MapperConfiguration(x => x.AddProfile(typeof(UsersServiceProfile)));
            Mapper = new Mapper(config);
        }
    }
}
