using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesWill.Migrations
{
    public partial class UpdateLanche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLanchePreferio",
                table: "Lanches",
                newName: "IsLanchePreferido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLanchePreferido",
                table: "Lanches",
                newName: "IsLanchePreferio");
        }
    }
}
