using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class image_field_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Items",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Items",
                newName: "gender");
        }
    }
}
