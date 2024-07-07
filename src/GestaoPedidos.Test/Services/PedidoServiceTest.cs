using Xunit;
using Moq;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Entities;
using System.Threading.Tasks;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace GestaoPedidos.Tests
{
    public class PedidoServiceTest
    {
        private readonly Mock<IPedidoRepository> _mockRepository;
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly PedidoService _service;

        public PedidoServiceTest()
        {
            _mockRepository = new Mock<IPedidoRepository>();
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _service = new PedidoService(_mockRepository.Object,_mockProdutoRepository.Object);
        }

        [Fact]
        public async Task CadastrarPedido_CallsInsertMethod_WithCorrectParameters()
        {
            // Arrange
            Pedido pedido = new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m};
            _mockRepository.Setup(repo => repo.Inserir(It.IsAny<Pedido>(), It.IsAny<IEnumerable<int>>()));
            _mockProdutoRepository.Setup(repo => repo.Obter()).ReturnsAsync(
                new List<Produto>()
                {
                    new Produto(1, "Teste", true, 1, 69.99m),
                    new Produto(2, "Outro Teste", false, 1, 59.99m)
                });

            // Act
            await _service.CadastrarPedido(1, new[] { 1 });

            // Assert
            _mockRepository.Verify(repo => repo.Inserir(It.IsAny<Pedido>(), It.IsAny<IEnumerable<int>>()), Times.Once);
        }

        [Fact]
        public void AtualizarPedido_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            Pedido pedido = new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m};
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Pedido>()));

            // Act
            _service.AtualizarPedido(pedido);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(pedido), Times.Once);
        }

        [Fact]
        public void ObterPedido_ReturnsExpectedPedido()
        {
            // Arrange
            var pedidoId = 1;
            Pedido pedido = new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m};
            _mockRepository.Setup(repo => repo.Obter(pedidoId)).Returns(pedido);

            // Act
            var result = _service.ObterPedido(pedidoId);

            // Assert
            Assert.Equal(pedido, result);
            _mockRepository.Verify(repo => repo.Obter(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void ObterTodosPedidos_ReturnsExpectedPedidos()
        {
            // Arrange
            var clienteId = 1;
            var pedidos = new List<Pedido>
            {
              new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m},
              new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m}
            }.AsQueryable();
            _mockRepository.Setup(repo => repo.ObterTodosPedidos(clienteId, null)).Returns(pedidos);

            // Act
            var result = _service.ObterTodosPedidos(clienteId, null);

            // Assert
            Assert.Equal(pedidos, result);
            _mockRepository.Verify(repo => repo.ObterTodosPedidos(clienteId, null), Times.Once);
        }

        [Fact]
        public void DeletarPedido_CallsDeleteMethod_WithCorrectParameters()
        {
            // Arrange
            var pedidoId = 1;
            _mockRepository.Setup(repo => repo.Deletar(pedidoId));

            // Act
            _service.DeletarPedido(pedidoId);

            // Assert
            _mockRepository.Verify(repo => repo.Deletar(pedidoId), Times.Once);
        }

        [Fact]
        public void ProximaEtapaPedido_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var pedidoId = 1;
            Pedido pedido = new () {DataPedido = DateTime.Now, Status = Status.Solicitado, Id = 1, HorarioFim = DateTime.Now, HorarioInicio = DateTime.Now.AddHours(2), ValorPedido = 150.00m};
            _mockRepository.Setup(repo => repo.Obter(pedidoId)).Returns(pedido);
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Pedido>()));

            // Act
            _service.ProximaEtapaPedido(pedidoId);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(It.IsAny<Pedido>()), Times.Once);
        }
    }
}