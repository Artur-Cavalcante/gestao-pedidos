using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Application.DTOs.Pagamento;
using GestaoPedidos.Infrastructure.Data.Entities.Pagamentos;

namespace GestaoPedidos.Application.Mappings
{
    [ExcludeFromCodeCoverage]
    public class PagamentoMappingProfile : Profile
    {
        public PagamentoMappingProfile()
        {
            CreateMap<Pagamento, PagamentoDto>();
            CreateMap<Pagamento, PagamentoEntity>();
            CreateMap<PagamentoEntity, Pagamento>().ConstructUsing(p => new Pagamento(p.Id, p.IdPedido, p.Status));
            CreateMap<PagamentoDto, Pagamento>().ConstructUsing(p => new Pagamento(p.Id, p.IdPedido, p.Status));
        }
    }
}
