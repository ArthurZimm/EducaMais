using EducaMais.Domain.Entities;
using EducaMais.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EducaMais.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas{ get; set; }

        ///TODO 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=EducaMaisDb;User Id=sa;Password=Arthur1!;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunoConfiguracao());
            modelBuilder.ApplyConfiguration(new MatriculaConfiguration());
        }
    }
}
