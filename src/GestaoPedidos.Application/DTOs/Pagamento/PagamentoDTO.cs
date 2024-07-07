﻿using System.Diagnostics.CodeAnalysis;
using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Application.DTOs.Pagamento
{
    
    [ExcludeFromCodeCoverage]
    public class PagamentoDTO
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public StatusPagamento Status { get; set; }
    }
}
