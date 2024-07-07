using GestaoPedidos.Infrastructure.Data.Entities.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CategoriaProdutoEntity> Categorias { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoriaProdutoEntity>(e =>
            {
                e.ToTable("categoria_produto");
            });
        }
    }
}
