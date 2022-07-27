using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditJobTitlesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInforamtionId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PersonalInforamtionId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PersonalInforamtionId",
                table: "JobTitles");

            migrationBuilder.RenameColumn(
                name: "PersonalJobTitleId",
                table: "PersonalInforamtions",
                newName: "JobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInforamtions_PersonalJobTitleId",
                table: "PersonalInforamtions",
                newName: "IX_PersonalInforamtions_JobTitleId");

            migrationBuilder.RenameColumn(
                name: "PersonalInforamtionId",
                table: "Hotels",
                newName: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                unique: true,
                filter: "[PersonalInformationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInforamtions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_JobTitleId",
                table: "PersonalInforamtions",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_JobTitleId",
                table: "PersonalInforamtions");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "JobTitleId",
                table: "PersonalInforamtions",
                newName: "PersonalJobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInforamtions_JobTitleId",
                table: "PersonalInforamtions",
                newName: "IX_PersonalInforamtions_PersonalJobTitleId");

            migrationBuilder.RenameColumn(
                name: "PersonalInformationId",
                table: "Hotels",
                newName: "PersonalInforamtionId");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInforamtionId",
                table: "JobTitles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PersonalInforamtionId",
                table: "Hotels",
                column: "PersonalInforamtionId",
                unique: true,
                filter: "[PersonalInforamtionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInforamtionId",
                table: "Hotels",
                column: "PersonalInforamtionId",
                principalTable: "PersonalInforamtions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_PersonalJobTitleId",
                table: "PersonalInforamtions",
                column: "PersonalJobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
