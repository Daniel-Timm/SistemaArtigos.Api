using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task <IEnumerable<Categoria>> ListarTodosAsync();
        Task <Categoria?> BuscarPorIdAsync(int id);
        Task RegistrarAsync(Categoria categoria); 
        Task RemoverAsync (int id);
        Task AtualizarAsync (Categoria categoria);
    }
}