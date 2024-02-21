using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Investment_InvestmentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Investment_InvestmentId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investment",
                table: "Investment");

            migrationBuilder.RenameTable(
                name: "Investment",
                newName: "Investments");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationId",
                table: "Administrators",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investments",
                table: "Investments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_NotificationId",
                table: "Administrators",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_Notifications_NotificationId",
                table: "Administrators",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id");

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
                name: "FK_Administrators_Notifications_NotificationId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Investments_InvestmentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Investments_InvestmentId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_NotificationId",
                table: "Administrators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investments",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Administrators");

            migrationBuilder.RenameTable(
                name: "Investments",
                newName: "Investment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investment",
                table: "Investment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Investment_InvestmentId",
                table: "Customers",
                column: "InvestmentId",
                principalTable: "Investment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Investment_InvestmentId",
                table: "Products",
                column: "InvestmentId",
                principalTable: "Investment",
                principalColumn: "Id");
        }
    }
}
