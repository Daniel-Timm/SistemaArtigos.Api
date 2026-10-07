using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasDeArtigosController : ControllerBase
    {
        private readonly ICategoriasDeArtigosService _service;

        public CategoriasDeArtigosController(ICategoriasDeArtigosService service)
        {
            _service = service;
        }

        [HttpGet("artigo/{idArtigo}")]
        public async Task<IActionResult> ObterCategoriasPorArtigo(int idArtigo)
        {
            try
            {
                var categorias = await _service.ObterCategoriasPorArtigoAsync(idArtigo);
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<IActionResult> ObterArtigosPorCategoria(int idCategoria)
        {
            try
            {
                var artigos = await _service.ObterArtigosPorCategoriaAsync(idCategoria);
                return Ok(artigos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarVinculo([FromBody] CategoriaDArtigo categoriaDArtigo)
        {
            try
            {
                await _service.AdicionarVinculoAsync(categoriaDArtigo);
                return StatusCode(201, new { mensagem = "Artigo vinculado à categoria com sucesso!" });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensagem = ex.Message }); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("artigo/{idArtigo}/categoria/{idCategoria}")]
        public async Task<IActionResult> RemoverVinculo(int idArtigo, int idCategoria)
        {
            try
            {
                await _service.RemoverVinculoAsync(idArtigo, idCategoria);
                return Ok(new { mensagem = "Vínculo removido com sucesso!" });
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