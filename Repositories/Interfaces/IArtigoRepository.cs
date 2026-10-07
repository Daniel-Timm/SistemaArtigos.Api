using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IArtigoRepository
    {
        Task<IEnumerable<Artigo>> ObterTodosAsync();
        Task <Artigo?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Artigo artigo);
        Task AtualizarAsync(Artigo artigo);
        Task RemoverAsync (int id );
        Task <IEnumerable<Artigo>> ObterPorAutorAsync(int idUsuario); 
        Task <IEnumerable<Artigo>> ObterPorNomeAsync (string nome);
    }
}