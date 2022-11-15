using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_api.Data.Dto.Endereco
{
    public class EnderecoCreateDTO
    {
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }
    }
}