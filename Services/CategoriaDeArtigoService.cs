using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Services
{
    public class CategoriasDeArtigosService : ICategoriasDeArtigosService
    {
        private readonly ICategoriasDeArtigosRepository _repository;

        public CategoriasDeArtigosService(ICategoriasDeArtigosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> ObterCategoriasPorArtigoAsync(int idArtigo)
        {
            return await _repository.ObterCategoriasPorArtigoAsync(idArtigo);
        }

        public async Task<IEnumerable<Artigo>> ObterArtigosPorCategoriaAsync(int idCategoria)
        {
            return await _repository.ObterArtigosPorCategoriaAsync(idCategoria);
        }

        public async Task AdicionarVinculoAsync(CategoriaDArtigo categoriaDArtigo)
        {
            bool jaExiste = await _repository.ExisteVinculoAsync(categoriaDArtigo.IdArtigo, categoriaDArtigo.IdCategoria);
            
            if (jaExiste)
            {
                throw new InvalidOperationException("Este artigo já está vinculado a esta categoria!");
            }

            await _repository.AdicionarVinculoAsync(categoriaDArtigo);
        }

        public async Task RemoverVinculoAsync(int idArtigo, int idCategoria)
        {
            bool jaExiste = await _repository.ExisteVinculoAsync(idArtigo, idCategoria);
            
            if (!jaExiste)
            {
                throw new InvalidOperationException("O vínculo entre este artigo e esta categoria não foi encontrado.");
            }

            await _repository.RemoverVinculoAsync(idArtigo, idCategoria);
        }
    }
}