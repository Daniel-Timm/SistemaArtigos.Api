using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Repositories.Interfaces
{
    public interface IFavoritosRepository
    {
        Task <IEnumerable<Artigo>> ListarPorUsuarioAsync(int idUsuario);
        Task AdicionarAsync(int idUsuario , int idArtigo);
        Task RemoverAsync (int idUsuario , int idArtigo);
        Task <bool>ExisteAsync(int idUsuario, int idArtigo);

    }

}