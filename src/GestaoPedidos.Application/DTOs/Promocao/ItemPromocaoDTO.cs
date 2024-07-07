using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Promocao
{
[ExcludeFromCodeCoverage]
public class ItemPromocaoDTO
    {
        public int IdPromocao { get; set; }
        public int IdProduto { get; set; }
        public decimal Desconto { get; set; }
    }
}
