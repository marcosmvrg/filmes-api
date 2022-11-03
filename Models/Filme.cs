

using System.ComponentModel.DataAnnotations;

namespace filmes_api.Models
{
    public class Filme
    {        

        public Filme(string Titulo, string Diretor) {
            this.Titulo = Titulo;
            this.Diretor = Diretor;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Diretor é obrigatório.")]
        public string Diretor { get; set; }
        
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres.")]
        public string ?Genero { get; set; }
        
        [Range(1, 300, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 300 minutos.")]
        public int Duracao { get; set; }

    }
}