namespace FSI.SmartPark.Domain.Entities.Operacional
{
    public class HorarioUnidade : EntityBase
    {
        public string Nome { get; private set; }
        public DateTime DataValidade { get; private set; }
        public int Unidade_Id { get; private set; }
        public bool Feriados { get; private set; }

        public bool EstaVigente() => DataValidade >= DateTime.Now;
    }
}
