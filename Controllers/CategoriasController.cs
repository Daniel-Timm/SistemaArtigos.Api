using System.Data.Common;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

using SistemaArtigos.API.Models;

using SistemaArtigos.API.Services.Interfaces;

namespace SistemaArtigos.API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]

     
     public class CategoriasController : ControllerBase
     {
          private readonly ICategoriaService _categoriaService;

          public CategoriasController (ICategoriaService categoriaService)
          {
               _categoriaService = categoriaService;
          }

         [HttpGet]
          public async Task <IActionResult> ObterTodos()
          {
               var categorias = await _categoriaService.ListarTodosAsync();
               return Ok(categorias);
          }


          [HttpGet("{id}")]
          public async Task <IActionResult> ObterPorIdAsync(int id)
          {
               var categoria = await _categoriaService.BuscarPorIdAsync(id);
               if(categoria == null)
               {
                    return NotFound();
               }
               return Ok(categoria);
          }


          [HttpPost("registrar")]
          public async Task <IActionResult> Registrar ([FromBody] Categoria categoria)
          {
              await _categoriaService.RegistrarAsync(categoria);
              return StatusCode(201, categoria);
          }


          [HttpPut ("{id}")]
          public async Task <IActionResult> Atualizar (int id, [FromBody] Categoria categoria)
          {
               if (id != categoria.IdCategoria)
               {
                    return BadRequest ("O id da URL não corresponde ao id do usuario enviado");
               }
               await _categoriaService.AtualizarAsync(categoria);
               return NoContent();
          }


          [HttpDelete ("{id}")]
          public async Task <IActionResult> Remover(int id)
          {
               await _categoriaService.RemoverAsync(id);
               return NoContent();
          }






     }

}