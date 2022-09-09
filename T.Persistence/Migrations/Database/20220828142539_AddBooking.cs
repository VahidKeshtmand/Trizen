using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class AddBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(7487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 743, DateTimeKind.Local).AddTicks(5203),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(4834),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(2925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(9781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 743, DateTimeKind.Local).AddTicks(585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(3493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(7449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(7263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(5346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(3169),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(8248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(3719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 100, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(5854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 100, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(6758));

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FlightId",
                table: "Booking",
                column: "FlightId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(1577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(7276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 743, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(2845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(1398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(9245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 103, DateTimeKind.Local).AddTicks(3848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 743, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(9045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(4719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 741, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(7259),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(5701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(4196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 100, DateTimeKind.Local).AddTicks(7261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 100, DateTimeKind.Local).AddTicks(8942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 739, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 101, DateTimeKind.Local).AddTicks(2444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 740, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 25, 14, 26, 20, 102, DateTimeKind.Local).AddTicks(6758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 28, 18, 55, 39, 742, DateTimeKind.Local).AddTicks(460));
        }
    }
}
