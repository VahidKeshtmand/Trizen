using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditTables7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmStatus",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(1003),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 114, DateTimeKind.Local).AddTicks(570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 114, DateTimeKind.Local).AddTicks(2497),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(8875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(1731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(3313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(8357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(9640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(8077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(6378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(2694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(1113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 110, DateTimeKind.Local).AddTicks(7611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 110, DateTimeKind.Local).AddTicks(9244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(4582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(6176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(9068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(6612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(2985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 114, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(6768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 114, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(4564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(2133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 113, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.AddColumn<int>(
                name: "ConfirmStatus",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(4064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(7980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(1871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(5),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(7831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(2925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(874),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 110, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(8239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 110, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(5541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 111, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 16, 37, 32, 112, DateTimeKind.Local).AddTicks(6176));
        }
    }
}
