using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.DTOs.Usuario;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuariosController : ControllerBase 
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController (IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var usuarios = await _usuarioService.ListarTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet ("{id}")]
        public async Task <IActionResult> ObterPorId (int id)
        {
            var usuario = await _usuarioService.BuscarPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound ();           
            }
            return Ok(usuario);
        }
        [HttpPost ("registrar")]
        public async Task <IActionResult> Registrar([FromBody] UsuarioRegistroDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email
            };

            try 
            {
                await _usuarioService.RegistrarAsync (usuario, dto.Senha);
                return StatusCode(201, usuario);
            }

            catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] UsuarioLoginDto dto)
        {
           var usuario = await _usuarioService.LoginAsync(dto.Email, dto.Senha);

           if(usuario == null )
           {
              return Unauthorized("E-mail ou senha inválidos");
           }
           return Ok(usuario);
        }



        [HttpPut("{id}")]
        public async Task <IActionResult> Atualizar (int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("O id da URL não corresponde ao id do usuário enviado.");
            }
             await _usuarioService.AtualizarAsync(usuario);

             return NoContent();
        }

        
        
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _usuarioService.RemoverAsync(id);
            return NoContent();
        }

    }
}