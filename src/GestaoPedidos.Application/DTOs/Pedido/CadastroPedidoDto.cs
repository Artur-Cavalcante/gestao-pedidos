using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Pedido;


[ExcludeFromCodeCoverage]
public class CadastroPedidoDto
{
    public int IdCliente { get; set; }
    public IEnumerable<int> Produtos { get; set; }
}