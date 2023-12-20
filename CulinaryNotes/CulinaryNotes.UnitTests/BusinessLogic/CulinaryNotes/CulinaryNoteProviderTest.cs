using CulinaryNotes.BusinessLogic.CulinaryNotes;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace CulinaryNotes.UnitTests.BusinessLogic.CulinaryNotes;

[TestFixture]
public class CulinaryNoteProviderTests
{
    [Test]
    public void TestGetAllCulinaryNotes()
    {
        Expression? expression = null;
        Mock<IRepository<CulinaryNoteEntity>> culinaryNotesRepository = new();

        culinaryNotesRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<CulinaryNoteEntity, bool>>>()))
            .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });

        var culinaryNotesProvider = new CulinaryNotesProvider(culinaryNotesRepository.Object, CulinaryNoteProviderMapperHelper.Mapper);
        var culinaryNoteFilter = new CulinaryNoteModelFilter()
        {
            Name = "name"
        };

        var culinaryNotes = culinaryNotesProvider.GetCulinaryNotes(culinaryNoteFilter);

        culinaryNotesRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<CulinaryNoteEntity, bool>>>()), Times.Exactly(1));
    }
}