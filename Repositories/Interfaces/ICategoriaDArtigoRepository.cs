using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface ICategoriasDeArtigosRepository
    {
        Task<IEnumerable<Categoria>> ObterCategoriasPorArtigoAsync(int idArtigo);
        Task<IEnumerable<Artigo>> ObterArtigosPorCategoriaAsync(int idCategoria);
        Task AdicionarVinculoAsync(CategoriaDArtigo categoriaDArtigo);
        Task RemoverVinculoAsync(int idArtigo, int idCategoria);
        Task<bool> ExisteVinculoAsync(int idArtigo, int idCategoria);
    }
}