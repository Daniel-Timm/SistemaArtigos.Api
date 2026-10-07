using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Services
{
    public class RascunhoDArtigoService : IRascunhoDArtigoService
    {
        private readonly IRascunhoDArtigoRepository _repository;

        public RascunhoDArtigoService(IRascunhoDArtigoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RascunhoDArtigo>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<RascunhoDArtigo?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<RascunhoDArtigo>> ObterPorUsuarioAsync(int idUsuario)
        {
            return await _repository.ObterPorUsuarioAsync(idUsuario);
        }

        public async Task AdicionarAsync(RascunhoDArtigo rascunho)
        {
            rascunho.DataCriacao = DateTime.Now;
            rascunho.DataAtualizacao = DateTime.Now;
            await _repository.AdicionarAsync(rascunho);
        }

        public async Task AtualizarAsync(RascunhoDArtigo rascunho)
        {
            bool existe = await _repository.ExisteAsync(rascunho.IdRascunho);
            if (!existe)
            {
                throw new InvalidOperationException("O rascunho informado não existe.");
            }

            rascunho.DataAtualizacao = DateTime.Now;
            await _repository.AtualizarAsync(rascunho);
        }

        public async Task RemoverAsync(int id)
        {
            bool existe = await _repository.ExisteAsync(id);
            if (!existe)
            {
                throw new InvalidOperationException("O rascunho informado não existe.");
            }

            await _repository.RemoverAsync(id);
        }
    }
}