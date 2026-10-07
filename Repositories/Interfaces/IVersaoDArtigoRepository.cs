using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IVersaoDArtigoRepository
    {
        Task<IEnumerable<VersaoDArtigo>> ObterPorArtigoAsync(int idArtigo);
        Task<VersaoDArtigo?> ObterPorIdAsync(int id);
        Task AdicionarAsync(VersaoDArtigo versao);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}