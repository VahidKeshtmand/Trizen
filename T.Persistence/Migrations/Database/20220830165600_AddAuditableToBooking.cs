using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class AddAuditableToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(2975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(9435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(1978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(7888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(5490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(4095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(5836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(4346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(2628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(8875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveDate",
                table: "Booking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Booking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(5488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(7662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(5560));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "RemoveDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Booking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(1426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(8374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(698),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(9018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(6265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 601, DateTimeKind.Local).AddTicks(4152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(8184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(3097),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(4009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(2366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 599, DateTimeKind.Local).AddTicks(449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(6094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(1540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(3540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 598, DateTimeKind.Local).AddTicks(8402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 22, 22, 28, 600, DateTimeKind.Local).AddTicks(5560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(7662));
        }
    }
}
