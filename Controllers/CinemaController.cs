using System.Collections;
using AutoMapper;
using filmes_api.Data;
using filmes_api.Data.Dto.Cinema;
using filmes_api.Mappers;
using filmes_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmes_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CinemaCreateDTO dto)
        {
            Cinema cinema = _mapper.Map<Cinema>(dto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IEnumerable<CinemaDTO> RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            List<CinemaDTO> response = new List<CinemaDTO>();
            foreach (var item in cinemas)
            {
                response.Add(CinemaMapper2.toDto(item));
            }            
            return response;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                CinemaDTO cinemaDto = _mapper.Map<CinemaDTO>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] CinemaUpdateDTO cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}