using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditAminetyRoomAndAminetyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "AmenityRooms");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AmenityRooms");

            migrationBuilder.DropColumn(
                name: "RemoveDate",
                table: "AmenityRooms");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AmenityRooms");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "AmenityHotels");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "AmenityHotels");

            migrationBuilder.DropColumn(
                name: "RemoveDate",
                table: "AmenityHotels");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AmenityHotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(6705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 347, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 345, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(9014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(7073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(3287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 346, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(5389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(3721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 343, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(1673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 343, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 688, DateTimeKind.Local).AddTicks(9554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 342, DateTimeKind.Local).AddTicks(7300));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 347, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 345, DateTimeKind.Local).AddTicks(3187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(9279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(4495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 346, DateTimeKind.Local).AddTicks(8775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 690, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 344, DateTimeKind.Local).AddTicks(650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 343, DateTimeKind.Local).AddTicks(6654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 343, DateTimeKind.Local).AddTicks(2269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 689, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "AmenityRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 346, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AmenityRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveDate",
                table: "AmenityRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AmenityRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "AmenityHotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 345, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "AmenityHotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveDate",
                table: "AmenityHotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AmenityHotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 15, 13, 7, 342, DateTimeKind.Local).AddTicks(7300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 15, 52, 52, 688, DateTimeKind.Local).AddTicks(9554));
        }
    }
}
