using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AdicionarTabelaLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    categoria_id = table.Column<int>(type: "INT", nullable: false),
                    preco = table.Column<decimal>(type: "DECIMAL(14,2)", precision: 14, scale: 2, nullable: false),
                    quantidade_paginas = table.Column<short>(type: "SMALLINT", nullable: false),
                    isbn = table.Column<string>(type: "VARCHAR(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_livro_categorias_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "livro",
                columns: new[] { "Id", "categoria_id", "isbn", "preco", "quantidade_paginas", "titulo" },
                values: new object[,]
                {
                    { 1, 1, "9781423121701", 42.60m, (short)400, "Percy Jackson 1" },
                    { 2, 3, "1492680788", 45.55m, (short)24, "Blockchain for Babies" },
                    { 3, 3, "9780132350884", 371.69m, (short)431, "Clean Code" },
                    { 4, 2, "8580417716", 20.90m, (short)256, "Querido Johnny" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_livro_categoria_id",
                table: "livro",
                column: "categoria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livro");
        }
    }
}
