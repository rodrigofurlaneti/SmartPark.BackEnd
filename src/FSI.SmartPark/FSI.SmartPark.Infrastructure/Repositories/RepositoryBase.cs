using Dapper;
using FSI.SmartPark.Domain.Interfaces;
using FSI.SmartPark.Infrastructure.Data;

namespace FSI.SmartPark.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class
{
    protected readonly SmartParkDbContext _ctx;
    protected abstract string Tabela { get; }

    protected RepositoryBase(SmartParkDbContext ctx) => _ctx = ctx;

    public virtual async Task<int> Inserir(TEntity entity)
    {
        using var conn = _ctx.CreateConnection();
        var props = typeof(TEntity)
            .GetProperties()
            .Where(p => p.Name != "Id" && p.CanWrite)
            .ToList();

        var colunas = string.Join(", ", props.Select(p => p.Name));
        var params_ = string.Join(", ", props.Select(p => $"@{p.Name}"));
        var sql = $"INSERT INTO SmartPark.{Tabela} ({colunas}) VALUES ({params_}); SELECT LAST_INSERT_ID();";

        return await conn.ExecuteScalarAsync<int>(sql, entity);
    }

    public virtual async Task<bool> Atualizar(TEntity entity)
    {
        using var conn = _ctx.CreateConnection();
        var props = typeof(TEntity)
            .GetProperties()
            .Where(p => p.Name != "Id" && p.CanWrite)
            .ToList();

        var sets = string.Join(", ", props.Select(p => $"{p.Name} = @{p.Name}"));
        var sql = $"UPDATE SmartPark.{Tabela} SET {sets} WHERE Id = @Id";

        var rows = await conn.ExecuteAsync(sql, entity);
        return rows > 0;
    }

    public virtual async Task<bool> Excluir(int id)
    {
        using var conn = _ctx.CreateConnection();
        var rows = await conn.ExecuteAsync($"DELETE FROM SmartPark.{Tabela} WHERE Id = @id", new { id });
        return rows > 0;
    }

    public virtual async Task<TEntity> ObterPorId(int id)
    {
        using var conn = _ctx.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<TEntity>(
            $"SELECT * FROM {Tabela} WHERE Id = @id", new { id })
            ?? throw new KeyNotFoundException($"{typeof(TEntity).Name} com Id {id} não encontrado.");
    }

    public virtual async Task<IEnumerable<TEntity>> ListarTodos()
    {
        try
        {
            using var conn = _ctx.CreateConnection();
            var resultado = await conn.QueryAsync<TEntity>($"SELECT * FROM SmartPark.{Tabela}");
            return resultado;
        }
        catch (Exception ex)
        {
            // Troque pelo seu logger
            Console.WriteLine($"[ERRO] ListarTodos - Tabela: {Tabela} | {ex.Message}");
            throw;
        }
    }
}
