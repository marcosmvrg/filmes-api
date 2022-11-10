using System.ComponentModel.DataAnnotations;


namespace filmes_api.Data.Dto.Cinema
{
    public class CinemaDTO
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public object Endereco { get; set; }
    }
}
