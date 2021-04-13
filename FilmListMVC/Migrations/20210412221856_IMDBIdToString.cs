using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmListMVC.Migrations
{
    public partial class IMDBIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMDBId",
                table: "Films",
                newName: "Imdbid");

            migrationBuilder.AlterColumn<string>(
                name: "Imdbid",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imdbid",
                table: "Films",
                newName: "IMDBId");

            migrationBuilder.AlterColumn<int>(
                name: "IMDBId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
