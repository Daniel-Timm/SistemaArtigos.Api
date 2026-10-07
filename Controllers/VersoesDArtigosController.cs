using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersoesDArtigosController : ControllerBase
    {
        private readonly IVersaoDArtigoService _service;

        public VersoesDArtigosController(IVersaoDArtigoService service)
        {
            _service = service;
        }

        [HttpGet("artigo/{idArtigo}")]
        public async Task<IActionResult> ObterPorArtigo(int idArtigo)
        {
            try
            {
                var versoes = await _service.ObterPorArtigoAsync(idArtigo);
                return Ok(versoes);
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
                var versao = await _service.ObterPorIdAsync(id);
                if (versao == null) 
                return NotFound(new { mensagem = "Versão não encontrada." });
                return Ok(versao);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] VersaoDArtigo versao)
        {
            try
            {
                await _service.AdicionarAsync(versao);
                return StatusCode(201, new { mensagem = "Versão registrada com sucesso!" });
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
                return Ok(new { mensagem = "Versão removida com sucesso!" });
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