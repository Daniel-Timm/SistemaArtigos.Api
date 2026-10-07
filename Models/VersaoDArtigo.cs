using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaArtigos.API.Models
{
    [Table("versoes_d_artigos")]
    public class VersaoDArtigo
    {
        [Key]
        [Column("id_versao")]
        public int IdVersao { get; set; }

        [Required]
        [Column("numero_versao")]
        public int NumeroVersao { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("titulo")]
        public string Titulo { get; set; } = null!;

        [Required]
        [Column("conteudo", TypeName = "text")]
        public string Conteudo { get; set; } = null!;

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("id_artigo")]
        public int IdArtigo { get; set; }
        //testar fk depois;;
        [ForeignKey("IdArtigo")]
        public Artigo? Artigo { get; set; }
    }
}