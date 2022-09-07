using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class _realestate_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Items",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Area",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Items");
        }
    }
}
