using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task <IEnumerable<Avaliacao>> ListarPorUsuariosAsync (int idUsuario);
        Task <IEnumerable<Avaliacao>> ListarPorArtigoAsync (int idArtigo);
        Task RegistrarAsync (int idUsuario, int idArtigo , int nota);
        Task AtualizarAsync(int idUsuario, int idArtigo, int nota);
        Task RemoverAsync(int idUsuario, int idArtigo);
        Task <bool> ExisteAsync(int idUsuario, int idArtigo);


    }
}