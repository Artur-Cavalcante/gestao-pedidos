using Xunit;
using Moq;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Entities;
using System.Threading.Tasks;
using GestaoPedidos.Application.Services;

namespace GestaoPedidos.Tests
{
    public class CategoriaServiceTest
    {
        private readonly Mock<ICategoriaProdutoRepository> _mockRepository;
        private readonly CategoriaProdutoService _service;

        public CategoriaServiceTest()
        {
            _mockRepository = new Mock<ICategoriaProdutoRepository>();
            _service = new CategoriaProdutoService(_mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarCategoriaProduto_CallsInsertMethod_WithCorrectParameters()
        {
            // Arrange
            var categoriaProduto = new CategoriaProduto(23, "Teste");
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<CategoriaProduto>())).Returns(Task.CompletedTask);

            // Act
            await _service.CadastrarCategoriaProduto(categoriaProduto);

            // Assert
            _mockRepository.Verify(repo => repo.Cadastrar(categoriaProduto), Times.Once);
        }

        [Fact]
        public async Task AtualizarCategoriaProduto_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var categoriaProduto = new CategoriaProduto(23, "Teste");
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<CategoriaProduto>())).Returns(Task.CompletedTask);

            // Act
            await _service.AtualizarCategoriaProduto(categoriaProduto);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(categoriaProduto), Times.Once);
        }

        [Fact]
        public async Task ObterCategoriaProduto_ReturnsExpectedCategoriaProduto()
        {
            // Arrange
            var categoriaId = 1;
            var categoriaProduto = new CategoriaProduto(23, "Teste");
            _mockRepository.Setup(repo => repo.Obter(categoriaId)).ReturnsAsync(categoriaProduto);

            // Act
            var result = await _service.ObterCategoriaProduto(categoriaId);

            // Assert
            Assert.Equal(categoriaProduto, result);
            _mockRepository.Verify(repo => repo.Obter(categoriaId), Times.Once);
        }

        [Fact]
        public async Task ObterTodosCategoriaProdutos_ReturnsExpectedCategoriaProdutos()
        {
            // Arrange
            var categorias = new List<CategoriaProduto>
            {
                new CategoriaProduto(23, "Teste"),
                new CategoriaProduto(23, "Teste")
            }.AsQueryable();
            _mockRepository.Setup(repo => repo.Obter()).ReturnsAsync(categorias);

            // Act
            var result = await _service.ObterCategoriaProduto();

            // Assert
            Assert.Equal(categorias, result);
            _mockRepository.Verify(repo => repo.Obter(), Times.Once);
        }

        [Fact]
        public async Task RemoverCategoriaProduto_CallsDeleteMethod_WithCorrectParameters()
        {
            // Arrange
            var categoriaId = 1;
            _mockRepository.Setup(repo => repo.Remover(categoriaId)).Returns(Task.CompletedTask);

            // Act
            await _service.RemoverCategoriaProduto(categoriaId);

            // Assert
            _mockRepository.Verify(repo => repo.Remover(categoriaId), Times.Once);
        }
    }
}