using System.ComponentModel.DataAnnotations;
using filmes_api.Data.Dto.Endereco;

namespace filmes_api.Data.Dto.Cinema
{
    public class CinemaDTO
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
