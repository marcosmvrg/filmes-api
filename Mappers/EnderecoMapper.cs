using AutoMapper;
using filmes_api.Data.Dto.Endereco;
using filmes_api.Models;

namespace filmes_api.Mappers
{
    public class EnderecoMapper : Profile
    {

        public EnderecoMapper()
        {
            CreateMap<EnderecoCreateDTO, Endereco>();       
            CreateMap<Endereco, EnderecoDTO>();       
            CreateMap<EnderecoUpdateDTO, Endereco>();   
        }
        
    }
}