using SisNet.Domain.Models;

namespace SisNet.Application.DTO
{
    public class CandidatoVagaDTO
    {
        #region vaga

        public Guid VagaId { get; set; }
        public Vaga Vaga { get; set; }

        #endregion

        #region Candidato

        public Guid CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        #endregion
    }
}
