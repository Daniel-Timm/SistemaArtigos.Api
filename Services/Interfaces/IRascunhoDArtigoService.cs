using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IRascunhoDArtigoService
    {
        Task<IEnumerable<RascunhoDArtigo>> ObterTodosAsync();
        Task<RascunhoDArtigo?> ObterPorIdAsync(int id);
        Task<IEnumerable<RascunhoDArtigo>> ObterPorUsuarioAsync(int idUsuario);
        Task AdicionarAsync(RascunhoDArtigo rascunho);
        Task AtualizarAsync(RascunhoDArtigo rascunho);
        Task RemoverAsync(int id);
    }
}