using filmes_api.Data.Dto.Cinema;
using filmes_api.Data.Dto.Endereco;
using filmes_api.Models;

namespace filmes_api.Mappers
{
    public class CinemaMapper2
    {
        public static CinemaDTO toDto(Cinema bo)
        {
            if (bo == null)
            {
                return null;
            }

            CinemaDTO dto = new CinemaDTO();
            dto.Id = bo.Id;
            dto.Nome = bo.Nome;
            dto.Endereco = new EnderecoDTO();
            dto.Endereco.Id = bo.Endereco.Id;
            dto.Endereco.Bairro = bo.Endereco.Bairro;
            dto.Endereco.Logradouro = bo.Endereco.Logradouro;
            dto.Endereco.Numero = bo.Endereco.Numero;
            return dto;
        }
    }
}