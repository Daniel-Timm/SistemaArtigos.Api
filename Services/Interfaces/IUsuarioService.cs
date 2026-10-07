using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Services.Interfaces

{
    // O service está chamando o Repositories
    // nao confundir
    public interface IUsuarioService{
        Task <IEnumerable<Usuario>> ListarTodosAsync();
        Task <Usuario?> BuscarPorIdAsync(int id);
        Task RegistrarAsync(Usuario usuario, string senhaTextoPuro);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(int id);
        Task <Usuario?> LoginAsync (string email, string senha);

    }
}