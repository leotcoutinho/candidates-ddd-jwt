namespace SisNet.Application.DTO
{
    public class CandidatoPostDTO
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cpf { get; set; }
        public required string Link { get; set; }
        public required DateTime DataNascimento { get; set; }
    }
}
