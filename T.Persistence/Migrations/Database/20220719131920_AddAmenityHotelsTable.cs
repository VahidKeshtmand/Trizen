using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T.Persistence.Migrations.Database
{
    public partial class AddAmenityHotelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Hotels_HotelId",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_HotelId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "PersonalInforamtions");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Amenities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInforamtions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(4404),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(2312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(9830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(7800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(7022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.CreateTable(
                name: "AmenityHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmenityHotels_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AmenityHotels_AmenityId",
                table: "AmenityHotels",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityHotels_HotelId",
                table: "AmenityHotels",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInforamtions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "AmenityHotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "PersonalInforamtions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(2804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "PersonalInforamtions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "JobTitles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "Hotels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(9280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(7536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 324, DateTimeKind.Local).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 478, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 16, 18, 55, 325, DateTimeKind.Local).AddTicks(4947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 49, 20, 479, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Amenities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                unique: true,
                filter: "[PersonalInformationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_HotelId",
                table: "Amenities",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Hotels_HotelId",
                table: "Amenities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_PersonalInforamtions_PersonalInformationId",
                table: "Hotels",
                column: "PersonalInformationId",
                principalTable: "PersonalInforamtions",
                principalColumn: "Id");
        }
    }
}
