using WebApiFuncionarios.Entities;

namespace WebApiFuncionarios.Interfaces;

public interface IFuncionarioService
{
    Task<IEnumerable<Funcionario>> GetFuncionariosAsync();
    Task<Funcionario?> GetFuncionarioByIdAsync(int id);
    Task AddFuncionarioAsync(Funcionario funcionario);
    Task UpdateFuncionarioAsync(Funcionario funcionario);
    Task DeleteFuncionarioAsync(int id);
}
