using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAdminPortal.API.Migrations
{
    public partial class ChangedStudentintoVolunteer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Address",
                newName: "VolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                newName: "IX_Address_VolunteerId");

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_GenderId",
                table: "Volunteer",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Volunteer_VolunteerId",
                table: "Address",
                column: "VolunteerId",
                principalTable: "Volunteer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Volunteer_VolunteerId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.RenameColumn(
                name: "VolunteerId",
                table: "Address",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_VolunteerId",
                table: "Address",
                newName: "IX_Address_StudentId");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_GenderId",
                table: "Student",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
