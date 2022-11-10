﻿
using System.ComponentModel.DataAnnotations;


namespace filmes_api.Data.Dto.Cinema
{
    public class CinemaCreateDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }
    }
}
