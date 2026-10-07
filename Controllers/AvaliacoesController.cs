using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacoesService; 
        public AvaliacoesController(IAvaliacaoService avaliacaoService)
        {
            _avaliacoesService = avaliacaoService;
        }




        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ListarPorUsuario (int idUsuario)
        {
            try
            {
                var avaliacoes = await _avaliacoesService.ListarPorUsuariosAsync(idUsuario);
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
        }



        [HttpGet("artigo/{idArtigo}")]
        public async Task <IActionResult> ListarPorArtigo (int idArtigo)
        {
            try
            {
                var avaliacoes = await _avaliacoesService.ListarPorArtigoAsync(idArtigo);
                return Ok (avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
        }



        [HttpPost]
        public async Task <IActionResult> Registrar([FromQuery] int idUsuario, [FromQuery] int idArtigo, [FromQuery] int nota)
        {
            try
            {
                await _avaliacoesService.RegistrarAsync(idUsuario, idArtigo, nota);
                return StatusCode(201, new {mensagem = "Avaliação publicada com sucesso!"});

            }
            catch
            {
                return StatusCode(500, new {mensagem = "Erro interno no servidor"});
            }
        }



        [HttpDelete ("{idUsuario}/{idArtigo}")]
        public async Task <IActionResult> Remover (int idUsuario, int idArtigo)
        {
            try
            {
                await _avaliacoesService.RemoverAsync(idUsuario, idArtigo);
                return Ok (new{mensagem = "Avaliação removida com sucesso!"});

            }
            catch
            {
                return StatusCode(500, new {mensagem = "Erro interno no servidor."});
            }
        }


        [HttpPut ("{idUsuario}/{idArtigo}")]
        public async Task <IActionResult> Atualizar (int idUsuario, int idArtigo, int nota)
        {
            try
            {
                await _avaliacoesService.AtualizarAsync(idUsuario, idArtigo, nota);
                return Ok(new {mensagem = "Avaliação atualizada com sucesso!"});

            }
            catch
            {
                return StatusCode (500, new {mensagem = "Erro interno do servidor."});
            }
        }

     



    }
}