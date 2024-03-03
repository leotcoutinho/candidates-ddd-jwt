using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisNet.Domain.Models;

namespace SisNet.Database.Mappings
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Codigo).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Descricao).IsRequired();
            builder.Property(x=>x.DataCadastro).IsRequired();
            builder.Property(x=>x.Ativo).IsRequired();
        }
    }
}
