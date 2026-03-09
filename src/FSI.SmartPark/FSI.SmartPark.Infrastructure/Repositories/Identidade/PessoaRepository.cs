using FSI.SmartPark.Domain.Entities.Identidade;
using FSI.SmartPark.Domain.Interfaces.Identidade;
using FSI.SmartPark.Infrastructure.Data;

namespace FSI.SmartPark.Infrastructure.Repositories.Identidade;

public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
{
    protected override string Tabela => "Pessoa";
    public PessoaRepository(SmartParkDbContext ctx) : base(ctx) { }
}
