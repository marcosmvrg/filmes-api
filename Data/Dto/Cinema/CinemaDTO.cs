using System.ComponentModel.DataAnnotations;


namespace filmes_api.Data.Dto.Cinema
{
    public class CinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public object Endereco { get; set; }
    }
}
