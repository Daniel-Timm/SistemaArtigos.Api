using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class ArtigoRepository : IArtigoRepository
    {
        private readonly AppDbContext _context; 

        public ArtigoRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Artigo>> ObterTodosAsync()
        {
             return await _context.Artigos.ToListAsync();
        }

        public async Task <Artigo?> ObterPorIdAsync (int id)
        {
             return await _context.Artigos.FindAsync(id);
              
        }

        public async Task AdicionarAsync (Artigo artigo)
        {
            await _context.Artigos.AddAsync(artigo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync (Artigo artigo) 
        {
            _context.Artigos.Update(artigo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync (int id)
        {
            var artigoLocalizado = await _context.Artigos.FindAsync(id);
            if (artigoLocalizado != null) 
            {
              _context.Artigos.Remove(artigoLocalizado); 
              await _context.SaveChangesAsync();
            }
         }


         public async Task <IEnumerable<Artigo>> ObterPorAutorAsync (int idUsuario)
         {
            return await _context.Artigos.Where(a => a.IdUsuario == idUsuario).ToListAsync();
            
         }
         public async Task<IEnumerable<Artigo>> ObterPorNomeAsync(string nome)
         {
            return await _context.Artigos.Where(a => a.Titulo.Contains(nome)).ToListAsync();
         }
    }
}