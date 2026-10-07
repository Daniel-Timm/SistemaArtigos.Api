using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class FavoritosController : ControllerBase
    {
        private readonly IFavoritoService _favoritoService;

        public FavoritosController(IFavoritoService favoritoService)
        {
            _favoritoService = favoritoService; 
        }



       [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ListarPorUsuario(int idUsuario)
        {
            try
            {
                var artigos = await _favoritoService.ListarPorUsuarioAsync(idUsuario);
                return Ok(artigos); // Retorna HTTP 200 com a lista de artigos
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task <IActionResult> Registrar([FromQuery] int idUsuario, [FromQuery] int idArtigo)
        {
            try
            {
                await _favoritoService.RegistrarAsync(idUsuario, idArtigo);
                return  StatusCode(201, new {mensagem = "Artigo favoritado com sucesso!"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {mensagem = "Erro interno no servidor"});
            }

        }
            [HttpDelete("{idUsuario}/{idArtigo}")]
            public async Task<IActionResult> Remover(int idUsuario, int idArtigo)
         {
            try
            {
                await _favoritoService.RemoverAsync(idUsuario, idArtigo);
                return Ok(new { mensagem = "Artigo removido dos favoritos com sucesso!" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor.", detalhes = ex.Message });
            }
         }
      
    }
}