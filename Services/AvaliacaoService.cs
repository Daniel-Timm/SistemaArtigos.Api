using System.Reflection.Metadata.Ecma335;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;
namespace SistemaArtigos.API.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository; 
        public  AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }



        public async Task <IEnumerable<Avaliacao>> ListarPorUsuariosAsync(int idUsuario)
        {
            return await _avaliacaoRepository.ListarPorUsuarioAsync(idUsuario);
        }


        public async Task <IEnumerable<Avaliacao>> ListarPorArtigoAsync(int idArtigo)
        {
            return await _avaliacaoRepository.ListarPorArtigoAsync(idArtigo);
        }


        public async Task RegistrarAsync (int idUsuario, int idArtigo, int nota)
        {
            bool jaExiste = await _avaliacaoRepository.ExisteAsync(idUsuario, idArtigo); 
            if(jaExiste)
            {
                throw new InvalidOperationException("O artigo já possui avaliação. ");
            }
            if(nota < 0 || nota > 10)
            {
                 throw new InvalidOperationException ("A nota deve estar entre 0 e 10.");
            }
            else
            {
                
                  await _avaliacaoRepository.AdicionarAsync(idUsuario, idArtigo, nota);
            }

        }


        public async Task RemoverAsync (int idUsuario, int idArtigo)
        {
            bool jaExiste = await _avaliacaoRepository.ExisteAsync(idUsuario, idArtigo);
            if(jaExiste)
            {
                await _avaliacaoRepository.RemoverAsync(idUsuario, idArtigo);
            }
            else
            {
                throw new InvalidOperationException ("Esta avaliação não existe para este artigo ou usuário...");
            }

        }


        public async Task AtualizarAsync (int idUsuario, int idArtigo, int nota)
        {
            bool jaExiste = await _avaliacaoRepository.ExisteAsync(idUsuario, idArtigo);
            if(jaExiste)
            {
                if (nota > 10 || nota < 0)
                {
                    throw new InvalidOperationException ("Valor inválido");
                }
                else
                {
                    await _avaliacaoRepository.AtualizarAsync(idUsuario, idArtigo , nota);
                }
            }
            else
            {
                throw new InvalidOperationException("Esta avaliação não existe!");
            }
        }

        public async Task <bool> ExisteAsync (int idUsuario, int idArtigo)
        {
            return await _avaliacaoRepository.ExisteAsync(idUsuario, idArtigo);
        }

        
    }




    




}