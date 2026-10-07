using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;
        public ComentarioRepository(AppDbContext context)
        {
            _context = context ;
        }




        public async Task <IEnumerable<Comentario>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _context.Comentarios
            .Where(c => c.IdUsuario == idUsuario)
            .Include(c => c.Artigo)
            .ToListAsync();
        }


        public async Task <IEnumerable<Comentario>> ObterPorArtigoAsync(int idArtigo)
        {
            return await _context.Comentarios
            .Where(c => c.IdArtigo == idArtigo && c.IdComentarioPai == null)
            .Include(c => c.Usuario)
            .Include (c => c.Respostas)
            .ThenInclude(r => r.Usuario)
            .ToListAsync();
        }



        public async Task AdicionarAsync(Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
        }


         public async Task AtualizarAsync(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            await _context.SaveChangesAsync();
        }
       



        public async Task RemoverAsync(int idComentario)
        {
            var comentario = await _context.Comentarios.FindAsync(idComentario);
            if(comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task <bool> ExisteAsync (int idComentario)
        {
            return await _context.Comentarios.AnyAsync(c => c.IdComentario == idComentario);
        }
    }
}