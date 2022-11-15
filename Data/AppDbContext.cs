using filmes_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace filmes_api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {            
            builder.Entity<Endereco>().HasOne<Cinema>(c => c.Cinema)
            .WithOne(s => s.Endereco).HasForeignKey<Cinema>(s => s.EnderecoID);            
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Gerente> Gerentes { get; set; }


    }
}