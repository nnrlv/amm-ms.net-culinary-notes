using CulinaryNotes.BusinessLogic.Users;
using CulinaryNotes.BusinessLogic.Users.Entities;
using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace CulinaryNotes.UnitTests.BusinessLogic.Users;

[TestFixture]
public class UserProviderTests
{
    [Test]
    public void TestGetAllUsers()
    {
        Expression? expression = null;
        Mock<IRepository<UserEntity>> usersRepository = new();

        usersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
            .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });

        var usersProvider = new UsersProvider(usersRepository.Object, UserProviderMapperHelper.Mapper);
        var userFilter = new UserModelFilter()
        {
            Name = "name"
        };

        var users = usersProvider.GetUsers(userFilter);

        usersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Exactly(1));
    }
}