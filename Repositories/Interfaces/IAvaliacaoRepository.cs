using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
       Task <IEnumerable<Avaliacao>> ListarPorUsuarioAsync(int idUsuario); // pra ter todos os avaliados por um usuario
       Task <IEnumerable<Avaliacao>> ListarPorArtigoAsync (int idArtigo); //pra ter a media de avaliaçoes geral
       Task AdicionarAsync (int idUsuario, int idArtigo , int nota);
       Task AtualizarAsync(int idUsuario, int idArtigo, int nota);
       Task RemoverAsync(int idUsuario, int idArtigo);
       Task <bool> ExisteAsync(int idUsuario, int idArtigo);
    }
}