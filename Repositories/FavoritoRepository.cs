using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class FavoritoRepository : IFavoritosRepository
    {
        private readonly AppDbContext _context;
        
        public FavoritoRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Artigo>> ListarPorUsuarioAsync(int idUsuario)
        {
            return await _context.Favoritos
                .Where(f => f.IdUsuario == idUsuario)
                .Select(f => f.Artigo)
                .ToListAsync();
        }

        public async Task AdicionarAsync(int idUsuario, int idArtigo)
        {   
            var favorito = new Favorito
            {
                IdUsuario = idUsuario,
                IdArtigo = idArtigo
            };
            await _context.Favoritos.AddAsync(favorito);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int idUsuario, int idArtigo)
        {
            var favorito = await _context.Favoritos.FindAsync(idUsuario, idArtigo);

            if (favorito != null)
            {
                _context.Favoritos.Remove(favorito);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteAsync(int idUsuario, int idArtigo)
        {
            return await _context.Favoritos
                .AnyAsync(f => f.IdUsuario == idUsuario && f.IdArtigo == idArtigo);
        }
    }
}