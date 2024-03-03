using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisNet.Domain.Models;

namespace SisNet.Database.Mappings
{
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(60).IsRequired();
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
        }
    }
}
