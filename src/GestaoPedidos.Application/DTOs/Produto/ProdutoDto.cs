using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Produto
{
[ExcludeFromCodeCoverage]
public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdCategoria { get; set; }
    }

[ExcludeFromCodeCoverage]
public class CategoriaProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;
    }
}
