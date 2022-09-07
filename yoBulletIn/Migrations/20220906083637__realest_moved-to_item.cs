using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yoBulletIn.Migrations
{
    public partial class _realest_movedto_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RealEstateId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_RealEstateId",
                table: "Items",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_RealEstateId",
                table: "Items",
                column: "RealEstateId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_RealEstateId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RealEstateId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Items");
        }
    }
}
