using AutoMapper;
using CulinaryNotes.WebAPI.Controllers.Mapper;

namespace CulinaryNotes.UnitTests.BusinessLogic.CulinaryNotes
{
    public class CulinaryNoteProviderMapperHelper
    {
        public static IMapper Mapper { get; }

        static CulinaryNoteProviderMapperHelper()
        {
            var config = new MapperConfiguration(x => x.AddProfile(typeof(CulinaryNotesServiceProfile)));
            Mapper = new Mapper(config);
        }
    }
}
