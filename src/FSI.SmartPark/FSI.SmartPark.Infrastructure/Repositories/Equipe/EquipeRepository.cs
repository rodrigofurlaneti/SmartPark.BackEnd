using FSI.SmartPark.Domain.Entities.Equipe;
using FSI.SmartPark.Domain.Interfaces.Equipe;
using FSI.SmartPark.Infrastructure.Data;

namespace FSI.SmartPark.Infrastructure.Repositories.Equipe;

public class EquipeRepository : RepositoryBase<Equipe>, IEquipeRepository
{
    protected override string Tabela => "Equipe";
    public EquipeRepository(SmartParkDbContext ctx) : base(ctx) { }
}
