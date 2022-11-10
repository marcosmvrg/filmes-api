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
            builder.Entity<Endereco>().HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco).HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }


    }
}