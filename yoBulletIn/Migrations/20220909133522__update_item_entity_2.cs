using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class _update_item_entity_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ItemOwnerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemOwnerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemOwnerId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ItemOwner",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_UserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemOwner",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ItemOwnerId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemOwnerId",
                table: "Items",
                column: "ItemOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ItemOwnerId",
                table: "Items",
                column: "ItemOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
