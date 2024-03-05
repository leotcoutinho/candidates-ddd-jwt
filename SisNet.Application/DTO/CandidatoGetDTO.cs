namespace SisNet.Application.DTO
{
    public class CandidatoGetDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cpf { get; set; }
        public required string Link { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
