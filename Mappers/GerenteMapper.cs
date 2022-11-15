using AutoMapper;
using filmes_api.Data.Dto.Gerente;
using filmes_api.Models;

namespace filmes_api.Mappers
{
    public class GerenteMapper: Profile
    {

        public GerenteMapper()
        {
            CreateMap<GerenteCreateDTO, Gerente>();
            CreateMap<Gerente, GerenteDTO>();
        }
        
    }
}