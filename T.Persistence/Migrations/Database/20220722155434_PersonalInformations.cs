using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class PersonalInformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_JobTitleId",
                table: "PersonalInforamtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInforamtions",
                table: "PersonalInforamtions");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "PersonalInforamtions",
                newName: "PersonalInformations");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInforamtions_JobTitleId",
                table: "PersonalInformations",
                newName: "IX_PersonalInformations_JobTitleId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(8225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(7716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(5438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(2749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(5656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(2736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInformations",
                table: "PersonalInformations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInformations_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformations_JobTitles_JobTitleId",
                table: "PersonalInformations",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInformations_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformations_JobTitles_JobTitleId",
                table: "PersonalInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInformations",
                table: "PersonalInformations");

            migrationBuilder.RenameTable(
                name: "PersonalInformations",
                newName: "PersonalInforamtions");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInforamtions",
                newName: "IX_PersonalInforamtions_JobTitleId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(8605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(6316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(4111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 369, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(5654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInforamtions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(2606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 20, 24, 34, 370, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInforamtions",
                table: "PersonalInforamtions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInforamtions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInforamtions_JobTitles_JobTitleId",
                table: "PersonalInforamtions",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
