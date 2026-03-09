namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class Unidade : EntityBase
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public int NumeroVaga { get; private set; }
        public bool Ativa { get; private set; }
        public string HorarioInicial { get; private set; }
        public string HorarioFinal { get; private set; }
        public int? Empresa_Id { get; private set; }

        public Unidade(string nome, int vagas)
        {
            if (vagas < 0) throw new Exception("Capacidade de vagas inválida");
            Nome = nome;
            NumeroVaga = vagas;
            Ativa = true;
        }

        public void AtualizarCapacidade(int novasVagas) => NumeroVaga = novasVagas;
    }
}
