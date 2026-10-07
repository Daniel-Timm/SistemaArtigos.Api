using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaArtigos.API.Models
{
    [Table("categorias_d_artigos")]
    [PrimaryKey(nameof(IdArtigo), nameof(IdCategoria))]
    public class CategoriaDArtigo
    {
        [Column("id_artigo")]
        public int IdArtigo { get; set; }

        [ForeignKey("IdArtigo")]
        public Artigo? Artigo { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
    }
}