using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Promocao
{
[ExcludeFromCodeCoverage]
public class HistoricoUsoPromocaoDTO
    {
        public int IdPromocao { get; set; }
        public int IdCliente { get; set; }
        public bool Utilizado { get; set; }
    }
}
