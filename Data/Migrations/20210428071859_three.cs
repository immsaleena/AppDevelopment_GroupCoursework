using Microsoft.EntityFrameworkCore.Migrations;

namespace coursework.Data.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_PurchaseID",
                table: "PurchaseDetails",
                column: "PurchaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Purchase_PurchaseID",
                table: "PurchaseDetails",
                column: "PurchaseID",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Purchase_PurchaseID",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_PurchaseID",
                table: "PurchaseDetails");
        }
    }
}
