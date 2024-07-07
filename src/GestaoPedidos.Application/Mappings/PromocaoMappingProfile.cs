using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using GestaoPedidos.Application.DTOs.Promocao;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Infrastructure.Data.Entities.Promocoes;

namespace GestaoPedidos.Application.Mappings
{
    [ExcludeFromCodeCoverage]
    public class PromocaoMappingProfile : Profile
    {
        public PromocaoMappingProfile()
        {
            CreateMap<Promocao, PromocaoDto>();
            CreateMap<Promocao, PromocaoEntity>();
            CreateMap<PromocaoEntity, Promocao>().ConstructUsing(p => new Promocao(p.Id, p.texto, p.status));
            CreateMap<PromocaoDto, Promocao>().ConstructUsing(p => new Promocao(p.Texto, p.Status));

            CreateMap<ItemPromocao, ItemPromocaoDto>();
            CreateMap<ItemPromocao, ItemPromocaoEntity>();
            CreateMap<ItemPromocaoEntity, ItemPromocao>().ConstructUsing(p => new ItemPromocao(p.idpromocao, p.idproduto, p.desconto));
            CreateMap<ItemPromocaoDto, ItemPromocao>().ConstructUsing(p => new ItemPromocao(p.IdPromocao, p.IdProduto, p.Desconto));

            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoDto>();
            CreateMap<HistoricoUsoPromocao, HistoricoUsoPromocaoEntity>();
            CreateMap<HistoricoUsoPromocaoEntity, HistoricoUsoPromocao>().ConstructUsing(p => new HistoricoUsoPromocao(p.idPromocao, p.idCliente, p.utilizado));
            CreateMap<HistoricoUsoPromocaoDto, HistoricoUsoPromocao>().ConstructUsing(p => new HistoricoUsoPromocao(p.IdPromocao, p.IdCliente, p.Utilizado));
        }
    }
}
