using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaArtigos.API.Models;




[Table("avaliacoes")] 
public class Avaliacao
{
    [Column("id_usuario")]
    public int IdUsuario {get; set;}


    [ForeignKey("IdUsuario")]
    public Usuario Usuario {get; set;} = null!;


    [Column("id_artigo")]
    public int IdArtigo{get; set;}


    [ForeignKey("IdArtigo")]
    public Artigo Artigo {get; set;} = null!;

    [Column("nota")]
    
    public int Nota {get; set;}


    [Column("data_avaliacao")]
    public DateTime DataDeAvaliacao {get; set;}



}