using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class EditTables6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInformations_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PersonalInformationId",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(9068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 859, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(6612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(2985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(6768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(4564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(2133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 859, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(4064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(7980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(1871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(5),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(7831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(2925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(874),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 855, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(8239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(5541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(6313));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 859, DateTimeKind.Local).AddTicks(2730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(5299),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "ReserveRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(7694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 860, DateTimeKind.Local).AddTicks(3330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 392, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(6189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 859, DateTimeKind.Local).AddTicks(5664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 391, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.AddColumn<int>(
                name: "PersonalInformationId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(9092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(3734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(3783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(1984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 389, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(9885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(5434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(3544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 855, DateTimeKind.Local).AddTicks(9466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(1461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 387, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 856, DateTimeKind.Local).AddTicks(7616),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 388, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "AirlineCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 15, 31, 47, 390, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 857, DateTimeKind.Local).AddTicks(9334)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 7, 23, 35, 57, 858, DateTimeKind.Local).AddTicks(1213)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformations_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_JobTitleId",
                table: "PersonalInformations",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInformations_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
