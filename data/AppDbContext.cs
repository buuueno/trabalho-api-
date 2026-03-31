using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>(produto =>
        {
            produto.Property(p => p.Nome)
                .HasMaxLength(120)
                .IsRequired();

            produto.Property(p => p.Preco)
                .HasPrecision(18, 2)
                .IsRequired();

            produto.Property(p => p.Estoque)
                .IsRequired();
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.Property(c => c.Nome)
                .HasMaxLength(80)
                .IsRequired();

            categoria.Property(c => c.Descricao)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<Cliente>(cliente =>
        {
            cliente.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            cliente.Property(c => c.Email)
                .HasMaxLength(200)
                .IsRequired();

            cliente.Property(c => c.Idade)
                .IsRequired();
        });
    }
}
