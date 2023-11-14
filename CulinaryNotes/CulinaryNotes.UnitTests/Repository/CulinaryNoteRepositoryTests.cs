using CulinaryNotes.DataAccess;
using CulinaryNotes.DataAccess.Entities;
using CulinaryNotes.UnitTests.Repository;
using FluentAssertions;
using NUnit.Framework;

namespace CulinaryNotes.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class CulinaryNoteRepositoryTests : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllCulinaryNotesTest()
    {
        // prepare

        using var context = DbContextFactory.CreateDbContext();
        var user = new UserEntity()
        {
            Name = "name1",
            Surname = "surname1",
            Email = "email1",
            PasswordHash = "passwordhash1",
            ExternalId = Guid.NewGuid()
        };
        var category = new CategoryEntity()
        {
            Name = "name1",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.Categories.Add(category);
        context.SaveChanges();

        var culinaryNotes = new CulinaryNoteEntity[]
        {
            new CulinaryNoteEntity()
            {
                Name = "name1",
                Description = "description1",
                Instructions = "instructions1",
                Rating = 4.8,
                ExternalId = Guid.NewGuid()
            },
            new CulinaryNoteEntity()
            {
                Name = "name2",
                Description = "description2",
                Instructions = "instructions2",
                Rating = 4.4,
                ExternalId = Guid.NewGuid()
            },
        };

        context.CulinaryNotes.AddRange(culinaryNotes);
        context.SaveChanges();

        // execute

        var repository = new Repository<CulinaryNoteEntity>(DbContextFactory);
        var actualCulinaryNotes = repository.GetAll();

        // assert

        actualCulinaryNotes.Should().BeEquivalentTo(culinaryNotes, options => options
        .Excluding(x => x.User)
        .Excluding(x => x.Category));
    }

    [Test]
    public void GetAllCulinaryNotesWithFilterTest()
    {
        // prepare

        using var context = DbContextFactory.CreateDbContext();
        var user = new UserEntity()
        {
            Name = "name1",
            Surname = "surname1",
            Email = "email1",
            PasswordHash = "passwordhash1",
            ExternalId = Guid.NewGuid()
        };
        var category = new CategoryEntity()
        {
            Name = "name1",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.Categories.Add(category);
        context.SaveChanges();

        var culinaryNotes = new CulinaryNoteEntity[]
        {
            new CulinaryNoteEntity()
            {
                Name = "name1",
                Description = "description1",
                Instructions = "instructions1",
                Rating = 4.8,
                ExternalId = Guid.NewGuid()
            },
            new CulinaryNoteEntity()
            {
                Name = "name2",
                Description = "description2",
                Instructions = "instructions2",
                Rating = 4.4,
                ExternalId = Guid.NewGuid()
            },
        };

        context.CulinaryNotes.AddRange(culinaryNotes);
        context.SaveChanges();

        //execute

        var repository = new Repository<CulinaryNoteEntity>(DbContextFactory);
        var actualCulinaryNotes = repository.GetAll(x => x.Name == "name1").ToArray();

        //assert
        actualCulinaryNotes.Should().BeEquivalentTo(culinaryNotes.Where(x => x.Name == "name1"));
    }

    [Test]
    public void SaveNewCulinaryNoteTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();

        // execute

        var user = new UserEntity()
        {
            Name = "name1",
            Surname = "surname1",
            Email = "email1",
            PasswordHash = "passwordhash1",
            ExternalId = Guid.NewGuid()
        };
        var category = new CategoryEntity()
        {
            Name = "name1",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.Categories.Add(category);
        context.SaveChanges();

        var culinaryNote = new CulinaryNoteEntity()
        {
            Name = "name1",
            Description = "description1",
            Instructions = "instructions1",
            Rating = 4.8,
            ExternalId = Guid.NewGuid()
        };

        var repository = new Repository<CulinaryNoteEntity>(DbContextFactory);
        repository.Save(culinaryNote);

        // assert

        var actualCulinaryNote = context.CulinaryNotes.SingleOrDefault();
        actualCulinaryNote.Should().BeEquivalentTo(culinaryNote, options => options.Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualCulinaryNote.Id.Should().NotBe(default);
        actualCulinaryNote.ModificationTime.Should().NotBe(default);
        actualCulinaryNote.CreationTime.Should().NotBe(default);
        actualCulinaryNote.ExternalId.Should().NotBe(Guid.Empty);
    }

    [Test]
    public void UpdateCulinaryNoteTest()
    {
        // prepare

        using var context = DbContextFactory.CreateDbContext();

        var user = new UserEntity()
        {
            Name = "name1",
            Surname = "surname1",
            Email = "email1",
            PasswordHash = "passwordhash1",
            ExternalId = Guid.NewGuid()
        };
        var category = new CategoryEntity()
        {
            Name = "name1",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.Categories.Add(category);
        context.SaveChanges();

        var culinaryNote = new CulinaryNoteEntity()
        {
            Name = "name1",
            Description = "description1",
            Instructions = "instructions1",
            Rating = 4.8,
            ExternalId = Guid.NewGuid()
        };

        context.CulinaryNotes.Add(culinaryNote);
        context.SaveChanges();

        // execute

        culinaryNote.Name = "new name1";
        culinaryNote.Description = "new description1";
        culinaryNote.Instructions = "new instructions1";
        culinaryNote.Rating = 4.0;
        var repository = new Repository<CulinaryNoteEntity>(DbContextFactory);
        repository.Save(culinaryNote);

        // assert

        var actualCulinaryNote = context.CulinaryNotes.SingleOrDefault();
        actualCulinaryNote.Should().BeEquivalentTo(culinaryNote);
    }


    [Test]
    public void DeleteUserTest()
    {
        // prepare

        using var context = DbContextFactory.CreateDbContext();

        var user = new UserEntity()
        {
            Name = "name1",
            Surname = "surname1",
            Email = "email1",
            PasswordHash = "passwordhash1",
            ExternalId = Guid.NewGuid()
        };
        var category = new CategoryEntity()
        {
            Name = "name1",
            ExternalId = Guid.NewGuid()
        };
        context.Users.Add(user);
        context.Categories.Add(category);
        context.SaveChanges();

        var culinaryNote = new CulinaryNoteEntity()
        {
            Name = "name1",
            Description = "description1",
            Instructions = "instructions1",
            Rating = 4.8,
            ExternalId = Guid.NewGuid()
        };

        context.CulinaryNotes.Add(culinaryNote);
        context.SaveChanges();

        //execute

        var repository = new Repository<CulinaryNoteEntity>(DbContextFactory);
        repository.Delete(culinaryNote);

        //assert
        context.CulinaryNotes.Count().Should().Be(0);
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    public void CleanUp()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.CulinaryNotes.RemoveRange(context.CulinaryNotes);
            context.SaveChanges();
        }
    }
}