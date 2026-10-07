using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IRascunhoDArtigoRepository
    {
        Task<IEnumerable<RascunhoDArtigo>> ObterTodosAsync();
        Task<RascunhoDArtigo?> ObterPorIdAsync(int id);
        Task<IEnumerable<RascunhoDArtigo>> ObterPorUsuarioAsync(int idUsuario);
        Task AdicionarAsync(RascunhoDArtigo rascunho);
        Task AtualizarAsync(RascunhoDArtigo rascunho);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}