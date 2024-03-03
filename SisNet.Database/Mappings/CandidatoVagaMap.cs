using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisNet.Domain.Models;

namespace SisNet.Database.Mappings
{
    public class CandidatoVagaMap : IEntityTypeConfiguration<CandidatoVaga>
    {
        public void Configure(EntityTypeBuilder<CandidatoVaga> builder)
        {
            //chave primária composta
            builder.HasKey(x => new { x.CandidatoId, x.VagaId });

            builder.HasOne(x => x.Vaga)
                   .WithMany(x => x.Candidatos)
                   .HasForeignKey(x => x.VagaId);

            builder.HasOne(x => x.Candidato)
                .WithMany(x => x.Vagas)
                .HasForeignKey(x => x.CandidatoId);

        }
    }
}
