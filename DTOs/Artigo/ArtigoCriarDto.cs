using SistemaArtigos.API.Models.Enums;
namespace SistemaArtigos.API.DTOs.Artigo
{
    public class ArtigoCriarDto
    {
        public int IdUsuario {get; set;} // mudar depois pra token de login
        public string Titulo {get; set;}
        public string Conteudo {get; set;}

        public EnumNivelArtigo  NivelArtigo {get; set;}
    }
}