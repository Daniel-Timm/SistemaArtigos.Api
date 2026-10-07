using Microsoft.EntityFrameworkCore;
using SistemaArtigos.API.Data;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;

namespace SistemaArtigos.API.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task <IEnumerable<Avaliacao>> ListarPorUsuarioAsync(int idUsuario)
        {
            return await _context.Avaliacoes.Where (a => a.IdUsuario == idUsuario)
            .ToListAsync();
        }


        public async Task <IEnumerable<Avaliacao>> ListarPorArtigoAsync (int idArtigo)
        {
            return await _context.Avaliacoes.Where (a => a.IdArtigo == idArtigo)
            .ToListAsync();
        }


        public async Task AdicionarAsync( int idUsuario, int idArtigo, int nota)
        {
            var avaliacao = new Avaliacao
            {
                IdUsuario = idUsuario,
                IdArtigo = idArtigo,
                Nota = nota
            };
            await _context.Avaliacoes.AddAsync(avaliacao);
            await _context.SaveChangesAsync();

        }


        public async Task RemoverAsync (int idUsuario, int idArtigo)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync( idUsuario, idArtigo);
            if(avaliacao != null )
            {
                _context.Avaliacoes.Remove(avaliacao); 
                await _context.SaveChangesAsync();
            }
        }


        public async Task <bool> ExisteAsync (int idUsuario, int idArtigo)
        {
            return await _context.Avaliacoes.AnyAsync(a => a.IdUsuario == idUsuario && a.IdArtigo == idArtigo);

        }

        public async Task AtualizarAsync( int idUsuario, int idArtigo, int nota)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(idUsuario, idArtigo); 
            if(avaliacao != null )
            {
                avaliacao.Nota = nota;
                await _context.SaveChangesAsync();
            }

        }


        

    }
}