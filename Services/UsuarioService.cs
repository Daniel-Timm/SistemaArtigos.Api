using SistemaArtigos.API.Models;
using SistemaArtigos.API.Repositories.Interfaces;
using SistemaArtigos.API.Services.Interfaces;
using SistemaArtigos.API.Models.Enums;

namespace SistemaArtigos.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ListarTodosAsync () 
        {

          return await _usuarioRepository.ObterTodosAsync();
        }

        public async Task<Usuario?> BuscarPorIdAsync(int id) 
        {
            return await _usuarioRepository.ObterPorIdAsync(id);
        }

        public async Task RegistrarAsync(Usuario usuario, string senhaTextoPuro)
        {

            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(usuario.Email);
            if(usuarioExistente != null)
            {
                throw new Exception ("Já exite um usuario cadastrado com este email.");
            }
            
            usuario.DataCadastro = DateTime.Now;
            usuario.NivelDeAcesso = NivelDeAcesso.Leitor;
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(senhaTextoPuro);
            await _usuarioRepository.AdicionarAsync(usuario);


        }
        
        public async Task AtualizarAsync(Usuario usuario)
        {
            await _usuarioRepository.AtualizarAsync(usuario);
        }
        
        public async Task RemoverAsync (int id)

        {
            await _usuarioRepository.RemoverAsync(id);
        }

        public async Task<Usuario?> LoginAsync (string email, string senha) 
        {
            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(email);

            if(usuarioExistente == null)
            {
                return null ;
            }
            
            if(BCrypt.Net.BCrypt.Verify(senha, usuarioExistente.SenhaHash))
            {
                return usuarioExistente;
            }
            
            return null;
        }
    }
}
