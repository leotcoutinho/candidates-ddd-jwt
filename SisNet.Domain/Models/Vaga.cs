using System.Threading.Tasks.Sources;

namespace SisNet.Domain.Models
{
    public class Vaga
    {
        public Vaga()
        {
                
        }
        public Vaga(int codigo, string titulo, string descricao)
        {    
            Codigo = codigo;
            Titulo = titulo;
            Descricao = descricao;
        }

        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string  Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }


        public IList<CandidatoVaga> Candidatos { get; set; }
    }
}
