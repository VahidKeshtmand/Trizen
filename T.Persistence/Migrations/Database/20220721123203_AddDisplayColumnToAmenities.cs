using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class AddDisplayColumnToAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInforamtions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(2606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(8605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(6316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(4111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(5654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Display",
                table: "Amenities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInforamtions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(4404),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(2312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(9830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(7800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 666, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(7022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 21, 17, 2, 2, 667, DateTimeKind.Local).AddTicks(5654));
        }
    }
}
