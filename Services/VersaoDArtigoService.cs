using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Services
{
    public class VersaoDArtigoService : IVersaoDArtigoService
    {
        private readonly IVersaoDArtigoRepository _repository;

        public VersaoDArtigoService(IVersaoDArtigoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VersaoDArtigo>> ObterPorArtigoAsync(int idArtigo)
        {
            return await _repository.ObterPorArtigoAsync(idArtigo);
        }

        public async Task<VersaoDArtigo?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(VersaoDArtigo versao)
        {
            versao.DataCriacao = DateTime.Now;
            await _repository.AdicionarAsync(versao);
        }

        public async Task RemoverAsync(int id)
        {
            bool existe = await _repository.ExisteAsync(id);
            if (!existe)
            {
                throw new InvalidOperationException("A versão informada não existe.");
            }

            await _repository.RemoverAsync(id);
        }
    }
}