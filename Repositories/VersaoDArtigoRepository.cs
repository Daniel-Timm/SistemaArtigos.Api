using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class VersaoDArtigoRepository : IVersaoDArtigoRepository
    {
        private readonly AppDbContext _context;

        public VersaoDArtigoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VersaoDArtigo>> ObterPorArtigoAsync(int idArtigo)
        {
            return await _context.VersoesDArtigos
                .Where(v => v.IdArtigo == idArtigo)
                .Include(v => v.Artigo)
                .ToListAsync();
        }

        public async Task<VersaoDArtigo?> ObterPorIdAsync(int id)
        {
            return await _context.VersoesDArtigos
                .Include(v => v.Artigo)
                .FirstOrDefaultAsync(v => v.IdVersao == id);
        }

        public async Task AdicionarAsync(VersaoDArtigo versao)
        {
            await _context.VersoesDArtigos.AddAsync(versao);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var versao = await ObterPorIdAsync(id);
            if (versao != null)
            {
                _context.VersoesDArtigos.Remove(versao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.VersoesDArtigos.AnyAsync(v => v.IdVersao == id);
        }
    }
}