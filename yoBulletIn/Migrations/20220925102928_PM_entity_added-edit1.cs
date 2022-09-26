using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class PM_entity_addededit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PMs_Items_ItemId",
                table: "PMs");

            migrationBuilder.DropIndex(
                name: "IX_PMs_ItemId",
                table: "PMs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "PMs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "PMs");

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
    }
}
