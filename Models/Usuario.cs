using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaArtigos.API.Models.Enums;
namespace SistemaArtigos.API.Models;

  [ Table ("usuarios")]
  public class Usuario {
    [Key]

    [Column ("id_usuario")]
    public int Id { get; set; }
   [Column ("nome")]
   [Required]
   [MaxLength(100)]
   public string Nome {get; set;}

   [Column ("email")]
   [Required]
   [MaxLength(100)]
  
   public string Email {get; set;}
   
   [Column ("senha_hash")]
   [Required]
   [MaxLength(255)]
   public string SenhaHash {get; set;}

   [Column ("nivel_d_acesso")]
   public NivelDeAcesso? NivelDeAcesso {get; set;}

   
  [Column ("score_reputacao")] public  int? ScoreReputacao {get; set;}
   
   
   [Column ("data_cadastro")]
   public  DateTime DataCadastro {get; set;}

 }

