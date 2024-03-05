namespace SisNet.Application.DTO
{
    public class VagaGetDTO
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
