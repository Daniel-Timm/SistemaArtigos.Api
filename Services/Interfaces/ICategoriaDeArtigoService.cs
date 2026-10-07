using SistemaArtigos.API.Models;

namespace SistemaArtigos.API.Services.Interfaces
{
    public interface ICategoriasDeArtigosService
    {
        Task<IEnumerable<Categoria>> ObterCategoriasPorArtigoAsync(int idArtigo);
        Task<IEnumerable<Artigo>> ObterArtigosPorCategoriaAsync(int idCategoria);
        Task AdicionarVinculoAsync(CategoriaDArtigo categoriaDArtigo);
        Task RemoverVinculoAsync(int idArtigo, int idCategoria);
    }
}