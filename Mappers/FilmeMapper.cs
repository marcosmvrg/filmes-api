using AutoMapper;
using filmes_api.Data.Dto.Filme;
using filmes_api.Models;

namespace filmes_api.Profiles
{
    public class FilmeMapper : Profile
    {
        
        public FilmeMapper() {
            CreateMap<FilmeFormDTO, Filme>();
            CreateMap<Filme, FilmeDTO>();
        }

    }
}