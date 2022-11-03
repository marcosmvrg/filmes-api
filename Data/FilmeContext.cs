using filmes_api.Models;
using Microsoft.EntityFrameworkCore;

namespace filmes_api.Data
{
    public class FilmeContext : DbContext
    {
        
        public FilmeContext(DbContextOptions<FilmeContext> options): base(options) {

        }        

        public DbSet<Filme> ?Filmes {get; set; }

    }
}