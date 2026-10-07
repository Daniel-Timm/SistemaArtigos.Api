using Microsoft.AspNetCore.Identity;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;
        public ComentarioService (IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }



        public async Task <IEnumerable<Comentario>> ObterPorArtigoAsync(int idArtigo)
        {
            return await _comentarioRepository.ObterPorArtigoAsync(idArtigo);
        }

        public async Task <IEnumerable<Comentario>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _comentarioRepository.ObterPorUsuarioAsync(idUsuario);
        }


        public async Task AdicionarAsync(Comentario comentario)
        {   
                     
               comentario.DataComentario = DateTime.Now;
               await _comentarioRepository.AdicionarAsync(comentario);
            

        }


        public async Task AtualizarAsync(Comentario comentario)
        {
            bool jaExiste = await _comentarioRepository.ExisteAsync(comentario.IdComentario);
            if(!jaExiste)
            {
                throw new InvalidOperationException ("O cometario não existe");
            }
            else
            {
              await _comentarioRepository.AtualizarAsync(comentario);
            }
        }


        public async Task RemoverAsync (int idComentario)
        {
            bool jaExiste = await _comentarioRepository.ExisteAsync(idComentario);
            if(jaExiste)
            {
                await _comentarioRepository.RemoverAsync(idComentario); 
                
            }
            else
            {
                throw new InvalidOperationException ("O comentário não existe!");
            };

        }

        
    }
}