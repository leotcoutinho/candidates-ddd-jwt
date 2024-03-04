using SisNet.Domain.Models;

namespace SisNet.Application.DTO
{
    public class CandidatoDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Link { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        // relacionamentos
        public IList<CandidatoVaga>? Vagas { get; set; }
    }
}
