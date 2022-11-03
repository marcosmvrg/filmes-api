using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController: ControllerBase
    {

        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost("add")]        
        public IActionResult AdicionaFilme([FromBody] Filme bo) { 
            bo.Id = id++;
            filmes.Add(bo);            
            return CreatedAtAction(nameof(ConsultaPorId), new {Id = bo.Id}, bo);
        }

        [HttpGet]
        public IActionResult ConsultaFilmes() {
            return Ok(filmes);
        }

        [HttpGet("{Id}")]        
        public IActionResult ConsultaPorId(int Id) {       
            Filme bo = filmes.FirstOrDefault(f => f.Id == Id);            

            if(bo != null) {
                return Ok(bo);
            }

            return NotFound();
        }

    }
}