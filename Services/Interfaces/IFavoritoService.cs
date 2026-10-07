using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IFavoritoService
    {
        Task <IEnumerable<Artigo>> ListarPorUsuarioAsync(int idUsuario);
        Task RegistrarAsync (int idUsuario, int idArtigo);
        Task RemoverAsync(int idUsuario, int idArtigo);
        Task <bool> ExisteAsync(int idUsuario, int IdArtigo);

    }
}