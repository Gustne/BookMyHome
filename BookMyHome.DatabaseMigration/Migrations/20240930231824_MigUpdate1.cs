using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class MigUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Ratings_RatingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Reviews_ReviewId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RatingId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookingId",
                table: "Ratings",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Bookings_BookingId",
                table: "Ratings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Bookings_BookingId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_BookingId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RatingId",
                table: "Bookings",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Ratings_RatingId",
                table: "Bookings",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Reviews_ReviewId",
                table: "Bookings",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
