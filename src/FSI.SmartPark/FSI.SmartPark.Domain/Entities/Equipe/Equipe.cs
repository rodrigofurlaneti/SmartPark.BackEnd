namespace FSI.SmartPark.Domain.Entities.Equipe
{
    public class Equipe : EntityBase
    {
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public int Unidade_Id { get; private set; }
        public int? Encarregado_Id { get; private set; }

        public Equipe(string nome, int unidadeId)
        {
            Nome = nome;
            Unidade_Id = unidadeId;
            Ativo = true;
        }
    }
}
