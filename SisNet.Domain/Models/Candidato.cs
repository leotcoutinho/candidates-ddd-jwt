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

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Link { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public IList<CandidatoVaga> Vagas { get; set; }
    }
}
