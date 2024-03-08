namespace SisNet.Domain.Models
{
    public class Candidato
    {
        public Candidato() { }

        public Candidato(Guid id, string nome, string email, string cpf, string link, DateTime dataNascimento, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Link = link;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Link { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        // refs
        public IList<CandidatoVaga> Vagas { get; set; }
    }
}
