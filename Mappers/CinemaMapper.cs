using AutoMapper;
using filmes_api.Data.Dto.Cinema;
using filmes_api.Models;

namespace filmes_api.Mappers
{
    public class CinemaMapper : Profile
    {

        public CinemaMapper()
        {
            CreateMap<CinemaCreateDTO, Cinema>();
            CreateMap<Cinema, CinemaDTO>();
            CreateMap<CinemaUpdateDTO, Cinema>();
        }



    }
}