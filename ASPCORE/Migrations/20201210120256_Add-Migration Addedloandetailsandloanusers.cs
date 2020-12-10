using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCORE.Migrations
{
    public partial class AddMigrationAddedloandetailsandloanusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "loanDetailsId",
                table: "Loanusers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loanusers_loanDetailsId",
                table: "Loanusers",
                column: "loanDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loanusers_loanDetails_loanDetailsId",
                table: "Loanusers",
                column: "loanDetailsId",
                principalTable: "loanDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loanusers_loanDetails_loanDetailsId",
                table: "Loanusers");

            migrationBuilder.DropIndex(
                name: "IX_Loanusers_loanDetailsId",
                table: "Loanusers");

            migrationBuilder.DropColumn(
                name: "loanDetailsId",
                table: "Loanusers");
        }
    }
}
