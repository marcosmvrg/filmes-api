using filmes_api.Data;
using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            this._context = context;
        }

        [HttpPost("add")]
        public IActionResult AdicionaFilme([FromBody] Filme bo)
        {

            _context.Filmes.Add(bo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ConsultaPorId), new { Id = bo.Id }, bo);
        }

        [HttpGet]
        public IEnumerable<Filme> ConsultaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{Id}")]
        public IActionResult ConsultaPorId(int Id)
        {

            Filme bo = _context.Filmes.SingleOrDefault(f => f.Id == Id);

            return bo != null ? Ok(bo) : NotFound();
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizaFilme(int Id, [FromBody] Filme filme) 
        {
            Filme bo = _context.Filmes.SingleOrDefault(f => f.Id == Id);

            if (bo == null)
            {
                return NotFound();
            }
            bo.Diretor = filme.Diretor;
            bo.Genero = filme.Genero;
            bo.Duracao = filme.Duracao;
            bo.Titulo = filme.Titulo;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaFilme(int Id) 
        {
            Filme bo = _context.Filmes.SingleOrDefault(f => f.Id == Id);

            if (bo == null)
            {
                return NotFound();
            }            
            _context.Filmes.Remove(bo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}