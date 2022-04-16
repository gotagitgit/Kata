using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kata.SuperMarket.Data.Migrations
{
    public partial class DeletePriceSchemeIdInStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockPriceSchemeId",
                table: "Stocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StockPriceSchemeId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
