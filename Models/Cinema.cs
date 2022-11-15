using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace filmes_api.Models
{
    public class Cinema
    {
        [Key]        
        public int Id { get; set; }

        public string Nome {get; set;}

        public virtual Endereco Endereco { get; set; }        

        public int EnderecoID { get; set; }

    }
}