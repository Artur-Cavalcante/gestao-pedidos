using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using GestaoPedidos.Application.DTOs.Pedido;
using GestaoPedidos.Infrastructure.Data.Entities.Pedidos;

namespace GestaoPedidos.Application.Mappings;

[ExcludeFromCodeCoverage]
public class PedidoMappingProfile : Profile
{
    public PedidoMappingProfile()
    {
        CreateMap<Domain.Entities.Pedido, PedidoEntity>().ReverseMap();

        CreateMap<Domain.Entities.Pedido, PedidoDto>().ReverseMap();
        CreateMap<Domain.Entities.Pedido, CadastroPedidoDto>().ReverseMap();
    }
}