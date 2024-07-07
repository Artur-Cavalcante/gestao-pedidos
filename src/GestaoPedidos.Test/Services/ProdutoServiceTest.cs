using Xunit;
using Moq;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Entities;
using System.Threading.Tasks;
using GestaoPedidos.Application.Services;
using Microsoft.Extensions.Logging;

namespace GestaoPedidos.Tests
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly ProdutoService _service;

        public ProdutoServiceTest()
        {
            _mockRepository = new Mock<IProdutoRepository>();
            _service = new ProdutoService(_mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarProduto_CallsAddMethod_WithCorrectParameters()
        {
            // Arrange
            var produto = new Produto(1, "Teste", true, 1, 99.99m);
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            await _service.CadastrarProduto(produto);

            // Assert
            _mockRepository.Verify(repo => repo.Cadastrar(produto), Times.Once);
        }

        [Fact]
        public async Task AtualizarProduto_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var produto = new Produto(1, "Updated Test", false, 1, 89.99m);
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            await _service.AtualizarProduto(produto);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(produto), Times.Once);
        }

        [Fact]
        public async Task ObterProduto_ReturnsExpectedProduto()
        {
            // Arrange
            var produtoId = 1;
            var produto = new Produto(produtoId, "Teste", true, 1, 79.99m);
            _mockRepository.Setup(repo => repo.Obter(produtoId)).ReturnsAsync(produto);

            // Act
            var result = await _service.ObterProduto(produtoId);

            // Assert
            Assert.Equal(produto, result);
            _mockRepository.Verify(repo => repo.Obter(produtoId), Times.Once);
        }

        [Fact]
        public async Task ObterProdutoPorCategoria_ReturnsExpectedProducts()
        {
            // Arrange
            var categoriaId = 1;
            var produtos = new List<Produto>
            {
                new Produto(1, "Teste", true, 1, 69.99m),
                new Produto(2, "Outro Teste", false, 1, 59.99m)
            }.AsQueryable();
            _mockRepository.Setup(repo => repo.ObterPorCategoria(categoriaId)).ReturnsAsync(produtos);

            // Act
            var result = await _service.ObterProdutoPorCategoria(categoriaId);

            // Assert
            Assert.Equal(produtos, result);
            _mockRepository.Verify(repo => repo.ObterPorCategoria(categoriaId), Times.Once);
        }

        [Fact]
        public async Task RemoverProduto_CallsRemoveMethod_WithCorrectParameters()
        {
            // Arrange
            var produtoId = 1;
            _mockRepository.Setup(repo => repo.Remover(produtoId)).Returns(Task.CompletedTask);

            // Act
            await _service.RemoverProduto(produtoId);

            // Assert
            _mockRepository.Verify(repo => repo.Remover(produtoId), Times.Once);
        }
    }
}