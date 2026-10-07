using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaArtigos.API.Models
{
    [Table("rascunhos_d_artigos")]
    public class RascunhoDArtigo
    {
        [Key]
        [Column("id_rascunho")]
        public int IdRascunho { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("titulo")]
        public string Titulo { get; set; } = null!;

        [Required]
        [Column("conteudo", TypeName = "text")]
        public string Conteudo { get; set; } = null!;

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}