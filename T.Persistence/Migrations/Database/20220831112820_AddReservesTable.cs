using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class AddReservesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(8319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 521, DateTimeKind.Local).AddTicks(7061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(4720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(2625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(9171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 521, DateTimeKind.Local).AddTicks(1771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(4253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(7951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(6429),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(4162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(1842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(6513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(3934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 516, DateTimeKind.Local).AddTicks(8349),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(1361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(9102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(1126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReserveRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReserveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveRooms_Reserves_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReserveRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveRooms_ReserveId",
                table: "ReserveRooms",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveRooms_RoomId",
                table: "ReserveRooms",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveRooms");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(2975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(9435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 521, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(1978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(7888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(5490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 521, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 592, DateTimeKind.Local).AddTicks(1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(4095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 519, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(5836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(4346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(2628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 518, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(8875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 516, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 589, DateTimeKind.Local).AddTicks(5488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 590, DateTimeKind.Local).AddTicks(782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 517, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 21, 26, 0, 591, DateTimeKind.Local).AddTicks(7662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 31, 15, 58, 20, 520, DateTimeKind.Local).AddTicks(1126));
        }
    }
}
