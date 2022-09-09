using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class _addedentities_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Clothes_ItemId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Electronics_Brand",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Electronics_ItemId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Electronics_Model",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Portable",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Clothes_ItemId",
                table: "Items",
                column: "Clothes_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Electronics_ItemId",
                table: "Items",
                column: "Electronics_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_Clothes_ItemId",
                table: "Items",
                column: "Clothes_ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_Electronics_ItemId",
                table: "Items",
                column: "Electronics_ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_Clothes_ItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_Electronics_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Clothes_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Electronics_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Clothes_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Electronics_Brand",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Electronics_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Electronics_Model",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Portable",
                table: "Items");
        }
    }
}
