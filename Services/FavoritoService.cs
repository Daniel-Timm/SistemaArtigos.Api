using System.Reflection.Metadata.Ecma335;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;
namespace SistemaArtigos.API.Services
{
    public class FavoritoService : IFavoritoService
    {
        private readonly IFavoritosRepository _favoritoRepository;
        
        public FavoritoService(IFavoritosRepository favoritoRepository)
        {
            
            _favoritoRepository = favoritoRepository;
        }



        
        
        public async Task <IEnumerable<Artigo>> ListarPorUsuarioAsync(int idUsuario)
        {
            return await _favoritoRepository.ListarPorUsuarioAsync(idUsuario);

        }

        public async Task RegistrarAsync (int idUsuario, int idArtigo)
        {
             bool jaExiste = await _favoritoRepository.ExisteAsync(idUsuario, idArtigo);

             if(jaExiste)
            {
                throw new InvalidOperationException("Este artigo já está nos favoritos do usuário.");
            }

            await _favoritoRepository.AdicionarAsync(idUsuario, idArtigo);

        }

        public async Task RemoverAsync (int idUsuario, int idArtigo)
        {
            bool existe = await _favoritoRepository.ExisteAsync(idUsuario, idArtigo);

            if(existe)
            {
                await _favoritoRepository.RemoverAsync( idUsuario, idArtigo);
            }
            else
            {
                
            throw new InvalidOperationException("Este artigo não está na sua lista de favoritos."); 
            }


        }

        public async Task <bool> ExisteAsync(int idUsuario, int idArtigo)
        {
            return await _favoritoRepository.ExisteAsync( idUsuario, idArtigo);
        }
        

    }

    

    

    
}