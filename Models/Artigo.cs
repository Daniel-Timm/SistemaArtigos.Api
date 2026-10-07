using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaArtigos.API.Models;
using SistemaArtigos.API.Models.Enums;

[Table ("artigos")]
public class Artigo {

[Key]
[Column ("id_artigo")] public int IdArtigo {get; set; }


[MaxLength (150)]
[Required]
[Column ("titulo")] public  string Titulo {get; set;}


[MaxLength (10000)]
[Required]
[Column ("conteudo")] public string Conteudo {get; set;}


  [Column ("status")] public EnumStatus  Status {get; set;}


[Column ("nivel_artigo")] public EnumNivelArtigo NivelArtigo {get; set;}

[Column ("id_usuario")] public int IdUsuario {get; set; }
[ForeignKey ("IdUsuario")] public Usuario Usuario {get; set;}




}