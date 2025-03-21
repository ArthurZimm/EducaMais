using EducaMais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducaMais.Infra.Data.Configurations
{
    public class AlunoConfiguracao : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Cpf)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(a => a.Senha)
                .IsRequired();

            builder.HasOne(a => a.Matricula)
                  .WithOne()
                  .HasForeignKey<Matricula>(m => m.AlunoId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(a => a.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua).HasMaxLength(200).IsRequired();
                endereco.Property(e => e.Numero).HasMaxLength(10).IsRequired();
                endereco.Property(e => e.Cidade).HasMaxLength(100).IsRequired();
                endereco.Property(e => e.Estado).HasMaxLength(100).IsRequired();
                endereco.Property(e => e.CodigoPostal).HasMaxLength(10).IsRequired();
            });
        }
    }
}