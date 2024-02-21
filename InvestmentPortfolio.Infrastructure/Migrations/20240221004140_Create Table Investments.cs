using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableInvestments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvestmentId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvestmentId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_InvestmentId",
                table: "Products",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InvestmentId",
                table: "Customers",
                column: "InvestmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Investments_InvestmentId",
                table: "Customers",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Investments_InvestmentId",
                table: "Products",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Investments_InvestmentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Investments_InvestmentId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Products_InvestmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_InvestmentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "Customers");
        }
    }
}
