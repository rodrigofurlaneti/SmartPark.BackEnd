namespace FSI.SmartPark.Domain.Entities.Financeiro
{
    public class ContaFinanceira : EntityBase
    {
        public string Descricao { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public bool ContaPadrao { get; private set; }
        public int? Banco_Id { get; private set; }
        public int Empresa_Id { get; private set; }
    }
}
