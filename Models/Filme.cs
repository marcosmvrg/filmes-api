

using System.ComponentModel.DataAnnotations;

namespace filmes_api.Models
{
    public class Filme
    {        

        public Filme(string Titulo, string Diretor, int Duracao) {
            this.Titulo = Titulo;
            this.Diretor = Diretor;
            this.Duracao = Duracao;
        }

        [Key]        
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public string Diretor { get; set; }
        
        public string ?Genero { get; set; }        
        
        public int Duracao { get; set; }

    }
}