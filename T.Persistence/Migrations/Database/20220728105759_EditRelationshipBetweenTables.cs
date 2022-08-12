using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditRelationshipBetweenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInformations");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CurrencyId",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(5787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 683, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(4067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 683, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(2098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(9842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 685, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(9218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(7523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 681, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AmenityHotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 684, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(5776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 681, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInformations",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CurrencyId",
                table: "Hotels",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInformations");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CurrencyId",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 683, DateTimeKind.Local).AddTicks(8406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 683, DateTimeKind.Local).AddTicks(3840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 685, DateTimeKind.Local).AddTicks(3353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(5340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 682, DateTimeKind.Local).AddTicks(998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 681, DateTimeKind.Local).AddTicks(6237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AmenityHotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 684, DateTimeKind.Local).AddTicks(4073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 743, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 1, 48, 50, 681, DateTimeKind.Local).AddTicks(1970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 28, 15, 27, 59, 742, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInformations",
                column: "JobTitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CurrencyId",
                table: "Hotels",
                column: "CurrencyId",
                unique: true);
        }
    }
}
