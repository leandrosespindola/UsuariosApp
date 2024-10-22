using Microsoft.EntityFrameworkCore;
using UsuariosApp.API.Entities;

namespace UsuariosApp.API.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.RefreshToken)
                .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.RefreshTokenExpiration);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

        }

        public DbSet<Usuario> Usuarios { get; set; }

        // Primeiro configuramos inMemory para teste.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("DBUsuarios");
        //}
    }
}
