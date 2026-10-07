using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;
using SistemaArtigos.API.Models.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SistemaArtigos.API.Services
{
    public class ArtigoService : IArtigoService
    {
        private readonly IArtigoRepository _artigoRepository;

        public ArtigoService(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        public async Task <IEnumerable<Artigo>> ListarTodosAsync ()
        {
            return await _artigoRepository.ObterTodosAsync();
        }

        public async Task <Artigo?> BuscarPorIdAsync(int id)
        {
            return await _artigoRepository.ObterPorIdAsync(id);
        }

        public async Task <IEnumerable<Artigo>> BuscarPorNomeAsync (string nome)
        {
            return await _artigoRepository.ObterPorNomeAsync(nome);
        }

        public async Task <IEnumerable<Artigo>> BuscarPorAutorIdAsync(int idUsuario)
        {
            return await _artigoRepository.ObterPorAutorAsync(idUsuario);
        }

        public async Task RegistrarAsync (Artigo artigo)
        {
           try
    {
        artigo.Status = EnumStatus.EmAnalise;
        await _artigoRepository.AdicionarAsync(artigo);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n\nERRO INTERNO DO BANCO: {ex.InnerException?.Message ?? ex.Message}\n\n");
        throw;
    }
        }

        public async Task RemoverAsync (int id)
        {
            await _artigoRepository.RemoverAsync(id);
        }
       
       public async Task AtualizarAsync (Artigo artigo)
        {
            await _artigoRepository.AtualizarAsync(artigo);
        }

        
       



    }
}