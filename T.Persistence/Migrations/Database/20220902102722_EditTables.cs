using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ReserveRooms",
                newName: "UnitPrice");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(1478),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(7979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 3, DateTimeKind.Local).AddTicks(607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 3, DateTimeKind.Local).AddTicks(2352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 29, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "ReserveRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(1473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(9923),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(7376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(4024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(8480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(3657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(5253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(3730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(1911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(7866),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(6309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(2691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 24, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(4348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 24, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(13),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(5889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(3481));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "ReserveRooms");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "ReserveRooms",
                newName: "TotalPrice");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(9525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(6749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(9862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 3, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 29, DateTimeKind.Local).AddTicks(1732),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 3, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(8408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(6649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(3957),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 28, DateTimeKind.Local).AddTicks(2340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 2, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(6170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 26, DateTimeKind.Local).AddTicks(1607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(9932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(7973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(3658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(1352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 24, DateTimeKind.Local).AddTicks(7384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 24, DateTimeKind.Local).AddTicks(9312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 21, 999, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 25, DateTimeKind.Local).AddTicks(5894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 0, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 0, 27, 53, 27, DateTimeKind.Local).AddTicks(3481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 2, 14, 57, 22, 1, DateTimeKind.Local).AddTicks(5889));
        }
    }
}
