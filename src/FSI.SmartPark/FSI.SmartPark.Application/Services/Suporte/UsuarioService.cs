using FSI.SmartPark.Application.DTOs.Suporte;
using FSI.SmartPark.Application.Interfaces.Suporte;
using FSI.SmartPark.Domain.Entities.Suporte;
using FSI.SmartPark.Domain.Interfaces.Suporte;
using System.Security.Cryptography;
using System.Text;

namespace FSI.SmartPark.Application.Services.Suporte;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo) => _repo = repo;

    public async Task<UsuarioResponseDto> Criar(UsuarioRequestDto dto)
    {
        var senhaHash = HashSenha(dto.Senha);
        var usuario = new Usuario(dto.Login, senhaHash, dto.UnidadeId);
        var id = await _repo.Inserir(usuario);
        var criado = await _repo.ObterPorId(id);
        return ToDto(criado!);
    }

    public async Task<TokenResponseDto> Autenticar(UsuarioLoginDto dto)
    {
        var lista = await _repo.ListarTodos();
        var usuario = lista.FirstOrDefault(u =>
            u.Login == dto.Login && u.Senha == HashSenha(dto.Senha) && u.Ativo)
            ?? throw new UnauthorizedAccessException("Login ou senha inválidos.");

        // Token simples — substituir por JWT em produção
        var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{usuario.Id}:{usuario.Login}:{DateTime.UtcNow:O}"));
        var expiracao = DateTime.UtcNow.AddHours(8);

        return new TokenResponseDto(token, expiracao, ToDto(usuario));
    }

    public async Task<UsuarioResponseDto?> ObterPorId(int id)
    {
        var u = await _repo.ObterPorId(id);
        return u is null ? null : ToDto(u);
    }

    public async Task Bloquear(int id)
    {
        var u = await _repo.ObterPorId(id)
            ?? throw new KeyNotFoundException($"Usuário {id} não encontrado.");
        u.Bloquear();
        await _repo.Atualizar(u);
    }

    private static string HashSenha(string senha)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(senha));
        return Convert.ToHexString(bytes).ToLower();
    }

    private static UsuarioResponseDto ToDto(Usuario u) => new(
        u.Id, u.Login, u.Ativo, u.Unidade_Id, u.Funcionario_Id);
}
