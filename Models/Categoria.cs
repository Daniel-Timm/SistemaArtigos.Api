using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaArtigos.API.Models.Enums;
namespace SistemaArtigos.API.Models;

[Table ("categorias")]
public class Categoria {
    [Key]
    [Column ("id_categoria")]
    public int IdCategoria { get; set; }

    [Column("nome")]
    [MaxLength(100)]
    [Required]
    public string Nome{ get; set; }


    [Column ("descricao")]
    [MaxLength (10000)]
    public string? Descricao { get; set;}

}
