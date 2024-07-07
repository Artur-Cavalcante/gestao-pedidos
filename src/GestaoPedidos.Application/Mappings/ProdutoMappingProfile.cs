using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using GestaoPedidos.Application.DTOs.Produto;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Infrastructure.Data.Entities.Produtos;

namespace GestaoPedidos.Application.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Produto, ProdutoEntity>();
            CreateMap<ProdutoEntity, Produto>().ConstructUsing(p => new Produto(p.Id, p.Nome, p.Status, p.IdCategoria, p.Preco));
            CreateMap<ProdutoDto, Produto>().ConstructUsing(p => new Produto(p.Id, p.Nome, p.Status, p.IdCategoria, p.Preco));

            CreateMap<CategoriaProduto, CategoriaProdutoDto>();
            CreateMap<CategoriaProduto, CategoriaProdutoEntity>();
            CreateMap<CategoriaProdutoEntity, CategoriaProduto>().ConstructUsing(c => new CategoriaProduto(c.Id, c.Nome));
            CreateMap<CategoriaProdutoDto, CategoriaProduto>().ConstructUsing(c => new CategoriaProduto(c.Id, c.Nome));
        }
    }
}
