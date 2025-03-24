using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiFuncionarios.Entities;
using WebApiFuncionarios.Interfaces;

namespace WebApiFuncionarios.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly string _connectionString;

    public FuncionarioRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Funcionario>("SELECT * FROM Funcionarios");
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Funcionario>("SELECT * FROM Funcionarios WHERE Id = @Id", new { Id = id });
    }

    public async Task AddAsync(Funcionario funcionario)
    {
        var sql = @"INSERT INTO Funcionarios 
                    (Nome, Cpf, Email, Telefone, Endereco, Cidade, Estado, DataNascimento, Cargo, Salario, DataAdmissao) 
                    VALUES 
                    (@Nome, @Cpf, @Email, @Telefone, @Endereco, @Cidade, @Estado, @DataNascimento, @Cargo, @Salario, @DataAdmissao)";
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(sql, funcionario);
    }

    public async Task UpdateAsync(Funcionario funcionario)
    {
        var sql = @"UPDATE Funcionarios SET 
                    Nome = @Nome, Cpf = @Cpf, Email = @Email, Telefone = @Telefone, Endereco = @Endereco,
                    Cidade = @Cidade, Estado = @Estado, DataNascimento = @DataNascimento, Cargo = @Cargo,
                    Salario = @Salario, DataAdmissao = @DataAdmissao
                    WHERE Id = @Id";
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(sql, funcionario);
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("DELETE FROM Funcionarios WHERE Id = @Id", new { Id = id });
    }
}
