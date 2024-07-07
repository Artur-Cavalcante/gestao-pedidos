using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Promocao
{
[ExcludeFromCodeCoverage]
public class PromocaoDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }  = string.Empty;
        public bool Status { get; set; }
    }
}
