using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;
// using SistemaArtigos.API.Models.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SistemaArtigos.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;      
       
        }
        
        public async Task <IEnumerable<Categoria>> ListarTodosAsync ()
        {
            return await _categoriaRepository.ObterTodosAsync();
        }

        public async Task  <Categoria?> BuscarPorIdAsync(int id)
        {
            return await _categoriaRepository.ObterPorIdAsync(id);
        }

        public async Task RegistrarAsync (Categoria categoria)
        {
           try
            {
                await  _categoriaRepository.AdicionarAsync(categoria);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nERRO INTERNO DO BANCO: {ex.InnerException?.Message ?? ex.Message}\n\n");
                throw;
            }
        }

        public async Task RemoverAsync (int id)
        {
            await _categoriaRepository.RemoverAsync(id);

        }

        public async Task AtualizarAsync (Categoria categoria)
        {
            await _categoriaRepository.AtualizarAsync(categoria);
        }


            
    
    
    
    }
}