using Microsoft.EntityFrameworkCore;
using WebApiFuncionarios.Entities;

namespace WebApiFuncionarios.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>().HasKey(f => f.Id);
        
    }
}
