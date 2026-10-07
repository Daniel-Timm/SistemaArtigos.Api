using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IVersaoDArtigoService
    {
        Task<IEnumerable<VersaoDArtigo>> ObterPorArtigoAsync(int idArtigo);
        Task<VersaoDArtigo?> ObterPorIdAsync(int id);
        Task AdicionarAsync(VersaoDArtigo versao);
        Task RemoverAsync(int id);
    }
}