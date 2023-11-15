using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CulinaryNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "units of measurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units of measurement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredients_units of measurement_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "units of measurement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "culinary_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_culinary_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_culinary_notes_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_culinary_notes_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ingredients in culinary notes",
                columns: table => new
                {
                    CulinaryNoteId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients in culinary notes", x => new { x.IngredientId, x.CulinaryNoteId });
                    table.ForeignKey(
                        name: "FK_ingredients in culinary notes_culinary_notes_CulinaryNoteId",
                        column: x => x.CulinaryNoteId,
                        principalTable: "culinary_notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ingredients in culinary notes_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user ratings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CulinaryNoteId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user ratings", x => new { x.UserId, x.CulinaryNoteId });
                    table.ForeignKey(
                        name: "FK_user ratings_culinary_notes_CulinaryNoteId",
                        column: x => x.CulinaryNoteId,
                        principalTable: "culinary_notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user ratings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_ExternalId",
                table: "admins",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_CategoryId",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ExternalId",
                table: "categories",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_culinary_notes_CategoryId",
                table: "culinary_notes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_culinary_notes_ExternalId",
                table: "culinary_notes",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_culinary_notes_UserId",
                table: "culinary_notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_ExternalId",
                table: "ingredients",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_UnitOfMeasurementId",
                table: "ingredients",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients in culinary notes_CulinaryNoteId",
                table: "ingredients in culinary notes",
                column: "CulinaryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_units of measurement_ExternalId",
                table: "units of measurement",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user ratings_CulinaryNoteId",
                table: "user ratings",
                column: "CulinaryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ExternalId",
                table: "users",
                column: "ExternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "ingredients in culinary notes");

            migrationBuilder.DropTable(
                name: "user ratings");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "culinary_notes");

            migrationBuilder.DropTable(
                name: "units of measurement");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
