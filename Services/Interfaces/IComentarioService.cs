using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<Comentario>> ObterPorArtigoAsync(int idArtigo);
        Task<IEnumerable<Comentario>> ObterPorUsuarioAsync(int idUsuario);
        Task AdicionarAsync(Comentario comentario);
        Task AtualizarAsync(Comentario comentario);
        Task RemoverAsync(int idComentario);
    }
}