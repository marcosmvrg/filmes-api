

using System.ComponentModel.DataAnnotations;

namespace filmes_api.Models
{
    public class Gerente
    {

        [Key]
        public int Id {get; set;}
        public string nome {get; set;}

    }
}