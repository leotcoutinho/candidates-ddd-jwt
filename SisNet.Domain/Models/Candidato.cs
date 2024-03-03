namespace SisNet.Domain.Models
{
    public class Candidato
    {
        public Candidato()
        {
                
        }

        public Candidato(string nome, string email, string cpf, string link, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Link = link;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Link { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public IList<CandidatoVaga> Vagas { get; set; }
    }
}
