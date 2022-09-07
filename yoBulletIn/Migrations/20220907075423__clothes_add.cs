using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class _clothes_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RealEstate_ItemId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_RealEstate_ItemId",
                table: "Items",
                column: "RealEstate_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_RealEstate_ItemId",
                table: "Items",
                column: "RealEstate_ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_RealEstate_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RealEstate_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RealEstate_ItemId",
                table: "Items");
        }
    }
}
