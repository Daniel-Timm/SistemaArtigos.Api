using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaArtigos.API.Models;

[Table("favoritos")]
public class Favorito
{
    //chaves sem key pq só pode um [key]
    
    [Column ("id_usuario")]
    public int IdUsuario {get; set;}


    [ForeignKey("IdUsuario")]
    public Usuario Usuario {get; set;} = null!; 



    
    [Column("id_artigo")]
    public int IdArtigo {get; set;}

    [ForeignKey ("IdArtigo")]
    public Artigo Artigo {get; set;} = null!;


}