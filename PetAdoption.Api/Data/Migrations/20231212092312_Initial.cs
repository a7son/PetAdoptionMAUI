using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoption.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AdoptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    AdoptedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.PetId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Breed", "DateOfBirth", "Description", "Gender", "Image", "IsActive", "Name", "Price", "Views" },
                values: new object[,]
                {
                    { 1, 0, "Dog - Golden Retriever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buddy is a friendly and playful Golden Retriever, known for being great with kids and owner", 0, "img_15.jpg", false, "Buddy", 300.0, 0 },
                    { 2, 0, "Cat - Siamese", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiskers is an elegant Siamese", 0, "img_2.jpg", false, "Whiskers", 150.0, 0 },
                    { 3, 0, "Dog - German Shepherd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is loyal and friendly", 0, "img_20.jpg", false, "Rocky", 400.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_PetId",
                table: "UserAdoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_UserId",
                table: "UserAdoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_PetId",
                table: "UserFavorites",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdoptions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
