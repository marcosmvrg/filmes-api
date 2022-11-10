
using AutoMapper;
using filmes_api.Data;
using filmes_api.Data.Dto.Endereco;
using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmes_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] EnderecoCreateDTO dto)
        {
            Endereco endereco = _mapper.Map<Endereco>(dto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperaEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                EnderecoDTO dto = _mapper.Map<EnderecoDTO>(endereco);

                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] EnderecoUpdateDTO dto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, endereco);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}