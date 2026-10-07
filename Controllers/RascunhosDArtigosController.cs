using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RascunhosDArtigosController : ControllerBase
    {
        private readonly IRascunhoDArtigoService _service;

        public RascunhosDArtigosController(IRascunhoDArtigoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var rascunhos = await _service.ObterTodosAsync();
                return Ok(rascunhos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var rascunho = await _service.ObterPorIdAsync(id);
                if (rascunho == null) return NotFound(new { mensagem = "Rascunho não encontrado." });
                return Ok(rascunho);
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
                var rascunhos = await _service.ObterPorUsuarioAsync(idUsuario);
                return Ok(rascunhos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] RascunhoDArtigo rascunho)
        {
            try
            {
                await _service.AdicionarAsync(rascunho);
                return StatusCode(201, new { mensagem = "Rascunho criado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] RascunhoDArtigo rascunho)
        {
            if (id != rascunho.IdRascunho)
            {
                return BadRequest(new { mensagem = "O ID da URL diverge do ID do objeto enviado." });
            }

            try
            {
                await _service.AtualizarAsync(rascunho);
                return Ok(new { mensagem = "Rascunho atualizado com sucesso!" });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _service.RemoverAsync(id);
                return Ok(new { mensagem = "Rascunho removido com sucesso!" });
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