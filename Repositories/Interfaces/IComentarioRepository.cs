using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IComentarioRepository
    {
        Task <IEnumerable<Comentario>> ObterPorUsuarioAsync(int idUsuario);
        Task <IEnumerable<Comentario>> ObterPorArtigoAsync(int idArtigo);
        Task AdicionarAsync(Comentario comentario);
        Task AtualizarAsync(Comentario comentario);
        Task RemoverAsync(int idComentario);
        Task <bool> ExisteAsync (int idComentario)
;
    }
}    