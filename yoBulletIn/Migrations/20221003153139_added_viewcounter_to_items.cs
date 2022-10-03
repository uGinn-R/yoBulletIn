using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class added_viewcounter_to_items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewsCounter",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PMs_ItemId",
                table: "PMs",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PMs_Items_ItemId",
                table: "PMs",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PMs_Items_ItemId",
                table: "PMs");

            migrationBuilder.DropIndex(
                name: "IX_PMs_ItemId",
                table: "PMs");

            migrationBuilder.DropColumn(
                name: "ViewsCounter",
                table: "Items");
        }
    }
}
