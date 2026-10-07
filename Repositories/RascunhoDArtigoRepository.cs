using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class RascunhoDArtigoRepository : IRascunhoDArtigoRepository
    {
        private readonly AppDbContext _context;

        public RascunhoDArtigoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RascunhoDArtigo>> ObterTodosAsync()
        {
            return await _context.RascunhosDArtigos
                .Include(r => r.Usuario)
                .ToListAsync();
        }

        public async Task<RascunhoDArtigo?> ObterPorIdAsync(int id)
        {
            return await _context.RascunhosDArtigos
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.IdRascunho == id);
        }

        public async Task<IEnumerable<RascunhoDArtigo>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _context.RascunhosDArtigos
                .Where(r => r.IdUsuario == idUsuario)
                .Include(r => r.Usuario)
                .ToListAsync();
        }

        public async Task AdicionarAsync(RascunhoDArtigo rascunho)
        {
            await _context.RascunhosDArtigos.AddAsync(rascunho);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(RascunhoDArtigo rascunho)
        {
            _context.RascunhosDArtigos.Update(rascunho);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var rascunho = await ObterPorIdAsync(id);
            if (rascunho != null)
            {
                _context.RascunhosDArtigos.Remove(rascunho);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.RascunhosDArtigos.AnyAsync(r => r.IdRascunho == id);
        }
    }
}