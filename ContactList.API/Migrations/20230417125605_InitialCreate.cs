using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactList.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Occupation", "PhoneNumber", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "Leati Joseph, Pensacola Florida", new DateTime(1985, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "roman@wwecorp.com", "Roman", 1, "Reign", "Wrestler", "08035003025", "images/reignwwe.jpg" },
                    { 2, "Uyo Street, Port Harcourt", new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@yahoo.com", "Sara", 0, "Field", "Doctor", "08028961586", "images/sara.png" },
                    { 3, "Asanjo, Lagos", new DateTime(1995, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "victor@gmail.com", "Victor", 1, "Unachukwu", "Software Engineer", "09025419260", "images/victor.jpg" },
                    { 4, "Riverside, Califor nia", new DateTime(1987, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ronda@wwecorp.com", "Ronda", 0, "Rousey", "Wrestler", "08037530139", "images/rosey.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
