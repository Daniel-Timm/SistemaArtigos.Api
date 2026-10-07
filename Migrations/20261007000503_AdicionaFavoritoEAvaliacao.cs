using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaArtigos.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaFavoritoEAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avaliacoes",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_artigo = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<int>(type: "int", nullable: false),
                    data_avaliacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacoes", x => new { x.id_usuario, x.id_artigo });
                    table.ForeignKey(
                        name: "FK_avaliacoes_artigos_id_artigo",
                        column: x => x.id_artigo,
                        principalTable: "artigos",
                        principalColumn: "id_artigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avaliacoes_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacoes_id_artigo",
                table: "avaliacoes",
                column: "id_artigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacoes");
        }
    }
}
