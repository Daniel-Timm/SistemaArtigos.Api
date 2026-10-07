using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentariosController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet("artigo/{idArtigo}")]
        public async Task<IActionResult> ObterPorArtigo(int idArtigo)
        {
            try
            {
                var comentarios = await _comentarioService.ObterPorArtigoAsync(idArtigo);
                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ObterPorUsuario(int idUsuario)
        {
            try
            {
                var comentarios = await _comentarioService.ObterPorUsuarioAsync(idUsuario);
                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Comentario comentario)
        {
            try
            {
                await _comentarioService.AdicionarAsync(comentario);
                return StatusCode(201, new { mensagem = "Comentário adicionado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{idComentario}")]
        public async Task<IActionResult> Atualizar(int idComentario, [FromBody] Comentario comentario)
        {
            if (idComentario != comentario.IdComentario)
            {
                return BadRequest(new { mensagem = "O ID da URL diverge do ID do objeto enviado." });
            }

            try
            {
                await _comentarioService.AtualizarAsync(comentario);
                return Ok(new { mensagem = "Comentário atualizado com sucesso!" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{idComentario}")]
        public async Task<IActionResult> Remover(int idComentario)
        {
            try
            {
                await _comentarioService.RemoverAsync(idComentario);
                return Ok(new { mensagem = "Comentário removido com sucesso!" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}