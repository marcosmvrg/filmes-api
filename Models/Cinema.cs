using System.ComponentModel.DataAnnotations;

namespace filmes_api.Models
{
    public class Cinema
    {
        [Key]        
        public int Id { get; set; }

        public string Nome {get; set;}

    }
}