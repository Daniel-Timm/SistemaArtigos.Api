using SistemaArtigos.API.Models;
namespace SistemaArtigos.API.Services.Interfaces
{
    public interface IArtigoService
    {
        Task <IEnumerable<Artigo>> ListarTodosAsync();//
        Task <Artigo?> BuscarPorIdAsync(int id);//
        Task <IEnumerable<Artigo> > BuscarPorNomeAsync (string nome);//
        Task <IEnumerable<Artigo >> BuscarPorAutorIdAsync (int usuarioId);
        Task RegistrarAsync(Artigo artigo); 
       
        Task RemoverAsync (int id);
        
        Task AtualizarAsync (Artigo artigo);

    }
}