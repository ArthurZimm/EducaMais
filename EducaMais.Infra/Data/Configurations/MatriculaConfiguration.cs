using EducaMais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducaMais.Infra.Data.Configurations
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Status)
                .IsRequired();

            builder.Property(m => m.DataInicial)
                .IsRequired();

            builder.Property(m => m.DataExpiracao)
                .IsRequired();

            builder.HasOne<Aluno>()
                .WithOne()
                .HasForeignKey<Matricula>(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
