using System.ComponentModel.DataAnnotations;

namespace filmes_api.Data.Dto.Cinema
{
    public class CinemaUpdateDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
