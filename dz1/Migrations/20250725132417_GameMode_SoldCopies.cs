using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dz1.Migrations
{
    /// <inheritdoc />
    public partial class GameMode_SoldCopies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameMode",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SoldCopies",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameMode",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SoldCopies",
                table: "Games");
        }
    }
}
