using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cash.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ClientAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ClientAccounts_AppUserId",
                table: "ClientAccounts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccounts_AspNetUsers_AppUserId",
                table: "ClientAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccounts_AspNetUsers_AppUserId",
                table: "ClientAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ClientAccounts_AppUserId",
                table: "ClientAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ClientAccounts");
        }
    }
}
