using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CriarTabelaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "nome" },
                values: new object[] { 1, "Ação" });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "nome" },
                values: new object[] { 2, "Romance" });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Id", "nome" },
                values: new object[] { 3, "Programação" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
