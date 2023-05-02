using Microsoft.EntityFrameworkCore.Migrations;

namespace coursework.Data.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesID",
                table: "SalesDetails",
                column: "SalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_Sales_SalesID",
                table: "SalesDetails",
                column: "SalesID",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_Sales_SalesID",
                table: "SalesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetails_SalesID",
                table: "SalesDetails");
        }
    }
}
