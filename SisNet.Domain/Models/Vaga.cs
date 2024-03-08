namespace SisNet.Domain.Models
{
    public class Vaga
    {
        public Vaga() { }

        public Vaga(Guid id, int codigo, string titulo, string descricao, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            Codigo = codigo;
            Titulo = titulo;
            Descricao = descricao;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        // refs
        public IList<CandidatoVaga> Candidatos { get; set; }
    }
}
