using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaArtigos.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTabelaComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    id_comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    conteudo = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_comentario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_artigo = table.Column<int>(type: "int", nullable: false),
                    id_comentario_pai = table.Column<int>(type: "int", nullable: true),
                    IdComentarioaPai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.id_comentario);
                    table.ForeignKey(
                        name: "FK_comentarios_artigos_id_artigo",
                        column: x => x.id_artigo,
                        principalTable: "artigos",
                        principalColumn: "id_artigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentarios_comentarios_id_comentario_pai",
                        column: x => x.id_comentario_pai,
                        principalTable: "comentarios",
                        principalColumn: "id_comentario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_id_artigo",
                table: "comentarios",
                column: "id_artigo");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_id_comentario_pai",
                table: "comentarios",
                column: "id_comentario_pai");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_id_usuario",
                table: "comentarios",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentarios");
        }
    }
}
