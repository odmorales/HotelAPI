using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookingHotelId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomHotelId",
                table: "BookingHotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingHotelId",
                table: "Guests",
                column: "BookingHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotels_RoomHotelId",
                table: "BookingHotels",
                column: "RoomHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHotels_RoomHotels_RoomHotelId",
                table: "BookingHotels",
                column: "RoomHotelId",
                principalTable: "RoomHotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_BookingHotels_BookingHotelId",
                table: "Guests",
                column: "BookingHotelId",
                principalTable: "BookingHotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHotels_RoomHotels_RoomHotelId",
                table: "BookingHotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_BookingHotels_BookingHotelId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingHotelId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_BookingHotels_RoomHotelId",
                table: "BookingHotels");

            migrationBuilder.DropColumn(
                name: "BookingHotelId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RoomHotelId",
                table: "BookingHotels");

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingHotelId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    RoomHotelId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_BookingHotels_BookingHotelId",
                        column: x => x.BookingHotelId,
                        principalTable: "BookingHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetails_RoomHotels_RoomHotelId",
                        column: x => x.RoomHotelId,
                        principalTable: "RoomHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_BookingHotelId",
                table: "BookingDetails",
                column: "BookingHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_GuestId",
                table: "BookingDetails",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomHotelId",
                table: "BookingDetails",
                column: "RoomHotelId");
        }
    }
}
