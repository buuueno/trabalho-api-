using Microsoft.EntityFrameworkCore;

namespace TarefasApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var tarefa = modelBuilder.Entity<Tarefa>();
        tarefa
            .Property(t => t.Nome)
            .HasMaxLength(120)
            .IsRequired();
    }
}
