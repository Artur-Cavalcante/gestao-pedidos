using System.Diagnostics.CodeAnalysis;
using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Application.DTOs.Pedido;

[ExcludeFromCodeCoverage]
public class AtualizarPedidoDto
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public int IdCliente { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }
}