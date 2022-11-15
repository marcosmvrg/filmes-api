
using AutoMapper;
using filmes_api.Data;
using filmes_api.Data.Dto.Gerente;
using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmes_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;                    
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] GerenteCreateDTO dto) {
            Gerente bo = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(bo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ConsultaPorId), new { Id = bo.Id }, bo);
        }

        [HttpGet]
        public IEnumerable<GerenteDTO> ConsultaGerentes()
        {
            return _mapper.Map(_context.Gerentes, new List<GerenteDTO>());
        }

         [HttpGet("{Id}")]
        public IActionResult ConsultaPorId(int Id)
        {
            Gerente bo = _context.Gerentes.Find(Id);
            if (bo == null) {
                return NotFound();
            }
            GerenteDTO dto = _mapper.Map<GerenteDTO>(bo);
            return Ok(dto);
        }


    }
}