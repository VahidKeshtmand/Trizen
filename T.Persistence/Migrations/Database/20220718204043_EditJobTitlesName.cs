using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditJobTitlesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInforamtions_PersonalJobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions");

            migrationBuilder.DropTable(
                name: "PersonalJobTitles");

            migrationBuilder.RenameColumn(
                name: "PersonalName",
                table: "PersonalInforamtions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PersonalEmail",
                table: "PersonalInforamtions",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInforamtionId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions",
                column: "PersonalJobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PersonalInforamtions",
                newName: "PersonalName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PersonalInforamtions",
                newName: "PersonalEmail");

            migrationBuilder.CreateTable(
                name: "PersonalJobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    PersonalInforamtionId = table.Column<int>(type: "int", nullable: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalJobTitles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInforamtions_PersonalJobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions",
                column: "PersonalJobTitleId",
                principalTable: "PersonalJobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
