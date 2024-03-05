namespace SisNet.Domain.Models
{
    public class Vaga
    {
        public Vaga()
        {

        }

        public Vaga(Guid id, int codigo, string titulo, string descricao, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            Codigo = codigo;
            Titulo = titulo;
            Descricao = descricao;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public Guid Id { get; private set; }
        public int Codigo { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }


        public IList<CandidatoVaga> Candidatos { get; set; }
    }
}
