using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaArtigos.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTabelaCategoriasDAertigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdComentarioaPai",
                table: "comentarios");

            migrationBuilder.CreateTable(
                name: "categorias_d_artigos",
                columns: table => new
                {
                    id_artigo = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias_d_artigos", x => new { x.id_artigo, x.id_categoria });
                    table.ForeignKey(
                        name: "FK_categorias_d_artigos_artigos_id_artigo",
                        column: x => x.id_artigo,
                        principalTable: "artigos",
                        principalColumn: "id_artigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorias_d_artigos_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_categorias_d_artigos_id_categoria",
                table: "categorias_d_artigos",
                column: "id_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias_d_artigos");

            migrationBuilder.AddColumn<int>(
                name: "IdComentarioaPai",
                table: "comentarios",
                type: "int",
                nullable: true);
        }
    }
}
