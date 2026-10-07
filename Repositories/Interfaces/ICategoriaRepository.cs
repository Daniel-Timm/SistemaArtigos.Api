using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
       Task<IEnumerable<Categoria>> ObterTodosAsync();
       Task <Categoria?> ObterPorIdAsync( int id);  
       Task AdicionarAsync(Categoria categoria);
       Task RemoverAsync (int id ); 
       Task AtualizarAsync (Categoria categoria);


    }
}