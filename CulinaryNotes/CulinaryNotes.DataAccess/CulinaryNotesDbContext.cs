using CulinaryNotes.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CulinaryNotes.DataAccess;

public class CulinaryNotesDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }
    public DbSet<CulinaryNoteEntity> CulinaryNotes { get; set; }
    public DbSet<UserRatingEntity> UserRatings{ get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<IngredientInCulinaryNoteEntity> IngredientsInCulinaryNotes { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<UnitOfMeasurementEntity> UnitsOfMeasurement { get; set; }

    public CulinaryNotesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //default identity server tables
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey(); ;
        modelBuilder.Entity<UserRoleEntity>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();

        // Admin
        modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

        // User
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasMany(x => x.CulinaryNotes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<UserEntity>().HasMany(x => x.UserRatings)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Culinary Note
        modelBuilder.Entity<CulinaryNoteEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CulinaryNoteEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<CulinaryNoteEntity>().HasMany(x => x.IngredientsInCulinaryNote)
           .WithOne(x => x.CulinaryNote)
           .HasForeignKey(x => x.CulinaryNoteId)
           .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<CulinaryNoteEntity>().HasMany(x => x.UserRatings)
           .WithOne(x => x.CulinaryNote)
           .HasForeignKey(x => x.CulinaryNoteId)
           .OnDelete(DeleteBehavior.NoAction);

        // Ingredient
        modelBuilder.Entity<IngredientEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<IngredientEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<IngredientEntity>().HasMany(x => x.IngredientsInCulinaryNote)
           .WithOne(x => x.Ingredient)
           .HasForeignKey(x => x.IngredientId)
           .OnDelete(DeleteBehavior.NoAction);

        // Unit Of Measurement
        modelBuilder.Entity<UnitOfMeasurementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UnitOfMeasurementEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UnitOfMeasurementEntity>().HasMany(x => x.Ingredients)
           .WithOne(x => x.UnitOfMeasurement)
           .HasForeignKey(x => x.UnitOfMeasurementId)
           .OnDelete(DeleteBehavior.NoAction);

        // Category
        modelBuilder.Entity<CategoryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoryEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<CategoryEntity>().HasMany(x => x.Categories)
           .WithOne(x => x.ParentCategory)
           .HasForeignKey(x => x.CategoryId)
           .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<CategoryEntity>().HasMany(x => x.CulinaryNotes)
           .WithOne(x => x.Category)
           .HasForeignKey(x => x.CategoryId)
           .OnDelete(DeleteBehavior.NoAction);

        // User Rating
        modelBuilder.Entity<UserRatingEntity>().HasKey(x => new { x.UserId, x.CulinaryNoteId });

        // Ingredient In Culinary Note
        modelBuilder.Entity<IngredientInCulinaryNoteEntity>().HasKey(x => new { x.IngredientId, x.CulinaryNoteId });
    }
}