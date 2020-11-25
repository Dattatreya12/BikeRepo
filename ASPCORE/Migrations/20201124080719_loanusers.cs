using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCORE.Migrations
{
    public partial class loanusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_makes_makeId",
                table: "Bikes");

            migrationBuilder.RenameColumn(
                name: "makeId",
                table: "Bikes",
                newName: "MakeID");

            migrationBuilder.RenameColumn(
                name: "MakID",
                table: "Bikes",
                newName: "makID");

            migrationBuilder.RenameIndex(
                name: "IX_Bikes_makeId",
                table: "Bikes",
                newName: "IX_Bikes_MakeID");

            migrationBuilder.AlterColumn<int>(
                name: "MakeID",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Loanusers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    Phoneno = table.Column<string>(nullable: true),
                    Loanstatus = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loanusers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_makes_MakeID",
                table: "Bikes",
                column: "MakeID",
                principalTable: "makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_makes_MakeID",
                table: "Bikes");

            migrationBuilder.DropTable(
                name: "Loanusers");

            migrationBuilder.RenameColumn(
                name: "makID",
                table: "Bikes",
                newName: "MakID");

            migrationBuilder.RenameColumn(
                name: "MakeID",
                table: "Bikes",
                newName: "makeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bikes_MakeID",
                table: "Bikes",
                newName: "IX_Bikes_makeId");

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "makeId",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_makes_makeId",
                table: "Bikes",
                column: "makeId",
                principalTable: "makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
