using System.Data.Common;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SistemaArtigos.API.DTOs.Artigo;
using SistemaArtigos.API.Models;
using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ArtigosController : ControllerBase
    {
        private readonly IArtigoService _artigoService;

        public ArtigosController (IArtigoService artigoService)
        {
            _artigoService = artigoService;
        }




        [HttpGet]
        public async Task <IActionResult> ObterTodos()
        {
            var artigos = await _artigoService.ListarTodosAsync();
            return Ok(artigos);
        }





        [HttpGet ("{id}")]
        public async Task <IActionResult> ObterPorIdAsync(int id)
        {
            var artigo = await _artigoService.BuscarPorIdAsync(id);
            if(artigo == null )
            {
                return NotFound();
            }

            return Ok(artigo);
        }




        [HttpPost("registrar")]
        public  async Task <IActionResult> Registrar ([FromBody] ArtigoCriarDto dto)
        {
            var artigo = new Artigo
            {
                Titulo = dto.Titulo,
                Conteudo = dto.Conteudo,
                NivelArtigo = dto.NivelArtigo,
                IdUsuario = dto.IdUsuario 
            };

            try
            {
                await _artigoService.RegistrarAsync(artigo);
                return StatusCode(201, artigo);
            }

            catch(Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }




       [HttpPut ("{id}")]
       public async Task <IActionResult> Atualizar (int id , [FromBody] Artigo artigo)
        {
            if (id != artigo.IdArtigo)
            {
                return BadRequest ("O id da URL não corresponde ao id do usuario enviado");
            }
            await _artigoService.AtualizarAsync(artigo);
            return NoContent();
        }
        



       [HttpDelete ("{id}")]
       public async Task <IActionResult> Remover(int id)
        {
            await _artigoService.RemoverAsync(id);
            return NoContent();
        } 



        [HttpGet("buscar")]
        public async Task <IActionResult> BuscarPorNome ([FromQuery] string nome)
        {
            var artigos = await _artigoService.BuscarPorNomeAsync(nome);
            return Ok (artigos);
        }



        [HttpGet("buscarAutor")]
        public async Task <IActionResult> BuscarPorAutor([FromQuery] int  IdUsuario)
        {
            var artigos = await _artigoService.BuscarPorAutorIdAsync(IdUsuario);
            return Ok (artigos);

        }
        


    }
}