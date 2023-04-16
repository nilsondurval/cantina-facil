using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaFacil.Infrastructure.Data.Migrations.AppMigrations
{
    public partial class Senha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TX_SENHA",
                table: "TB_USUARIO",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TX_SENHA",
                table: "TB_USUARIO");
        }
    }
}
