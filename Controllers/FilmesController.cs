using AutoMapper;
using filmes_api.Data;
using filmes_api.Data.Dto;
using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmesController(FilmeContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult AdicionaFilme([FromBody] FilmeFormDTO dto)
        {
            Filme bo = _mapper.Map<Filme>(dto);
            _context.Filmes.Add(bo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ConsultaPorId), new { Id = bo.Id }, bo);
        }

        [HttpGet]
        public IEnumerable<FilmeDTO> ConsultaFilmes()
        {
            return _mapper.Map(_context.Filmes, new List<FilmeDTO>());
        }

        [HttpGet("{Id}")]
        public IActionResult ConsultaPorId(int Id)
        {

            Filme bo = _context.Filmes.SingleOrDefault(f => f.Id == Id);
            if (bo == null) {
                return NotFound();
            }
            FilmeDTO dto = _mapper.Map<FilmeDTO>(bo);
            return Ok(dto);
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizaFilme(int Id, [FromBody] FilmeFormDTO dto) 
        {
            Filme bo = _context.Filmes.SingleOrDefault(f => f.Id == Id);

            if (bo == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, bo);
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