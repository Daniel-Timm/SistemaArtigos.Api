using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context; 


        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Categoria>> ObterTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }




       public async Task <Categoria?> ObterPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }


        public async Task AdicionarAsync (Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync (Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();

        }

        public async Task RemoverAsync (int id)
        {
            var categoriaLocalizada = await _context.Categorias.FindAsync(id);
            if(categoriaLocalizada != null)
            {
                _context.Categorias.Remove(categoriaLocalizada);
                await _context.SaveChangesAsync();
            }
        }


    }
}