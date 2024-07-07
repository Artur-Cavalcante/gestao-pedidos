using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Produto
{
[ExcludeFromCodeCoverage]
public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdCategoria { get; set; }
    }

[ExcludeFromCodeCoverage]
public class CategoriaProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
