using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaArtigos.API.Models
{
    [Table("comentarios")]
    public class Comentario
    {
        [Key]
        [Column("id_comentario")]
        public int IdComentario { get; set; }
        [Required]
        [Column("conteudo", TypeName = "text")]
        public string Conteudo { get; set; } = null!;
        [Column("data_comentario")]
        public DateTime DataComentario { get; set; } = DateTime.Now;
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
        [Column("id_artigo")]
        public int IdArtigo { get; set; }
        [ForeignKey("IdArtigo")]
        public Artigo? Artigo { get; set; }
        [Column("id_comentario_pai")]
        public int? IdComentarioPai { get; set; }
        [ForeignKey("IdComentarioPai")]
        public Comentario? ComentarioPai { get; set; }
        public ICollection<Comentario> Respostas { get; set; } = new List<Comentario>();
    }
}