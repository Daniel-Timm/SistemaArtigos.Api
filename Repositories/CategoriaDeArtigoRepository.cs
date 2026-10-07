using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class CategoriasDeArtigosRepository : ICategoriasDeArtigosRepository
    {
        private readonly AppDbContext _context;

        public CategoriasDeArtigosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObterCategoriasPorArtigoAsync(int idArtigo)
        {
            return await _context.CategoriasDArtigos
                .Where(ca => ca.IdArtigo == idArtigo)
                .Include(ca => ca.Categoria)
                .Select(ca => ca.Categoria!)
                .ToListAsync();
        }

        public async Task<IEnumerable<Artigo>> ObterArtigosPorCategoriaAsync(int idCategoria)
        {
            return await _context.CategoriasDArtigos
                .Where(ca => ca.IdCategoria == idCategoria)
                .Include(ca => ca.Artigo)
                .Select(ca => ca.Artigo!)
                .ToListAsync();
        }

        public async Task AdicionarVinculoAsync(CategoriaDArtigo categoriaDArtigo)
        {
            await _context.CategoriasDArtigos.AddAsync(categoriaDArtigo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverVinculoAsync(int idArtigo, int idCategoria)
        {
            var vinculo = await _context.CategoriasDArtigos
                .FirstOrDefaultAsync(ca => ca.IdArtigo == idArtigo && ca.IdCategoria == idCategoria);
            
            if (vinculo != null)
            {
                _context.CategoriasDArtigos.Remove(vinculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteVinculoAsync(int idArtigo, int idCategoria)
        {
            return await _context.CategoriasDArtigos
                .AnyAsync(ca => ca.IdArtigo == idArtigo && ca.IdCategoria == idCategoria);
        }
    }
}