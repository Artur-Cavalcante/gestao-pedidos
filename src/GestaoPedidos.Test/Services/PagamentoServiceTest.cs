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
    public class PagamentoServiceTest
    {
        private readonly Mock<IPagamentoRepository> _mockRepository;
        private readonly PagamentoService _service;

        public PagamentoServiceTest()
        {
            _mockRepository = new Mock<IPagamentoRepository>();
            _service = new PagamentoService(_mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarPagamento_CallsInsertMethod_WithCorrectParameters()
        {
            // Arrange
            var pagamento = new Pagamento(1, 2, StatusPagamento.Aprovado);
            _mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Pagamento>())).Returns(Task.CompletedTask);

            // Act
            await _service.CadastrarPagamento(pagamento);

            // Assert
            _mockRepository.Verify(repo => repo.Cadastrar(pagamento), Times.Once);
        }

        [Fact]
        public async Task AtualizarPagamento_CallsUpdateMethod_WithCorrectParameters()
        {
            // Arrange
            var pagamento = new Pagamento(1, 2, StatusPagamento.Aprovado);
            _mockRepository.Setup(repo => repo.Atualizar(It.IsAny<Pagamento>())).Returns(Task.CompletedTask);

            // Act
            await _service.AtualizarPagamento(pagamento);

            // Assert
            _mockRepository.Verify(repo => repo.Atualizar(pagamento), Times.Once);
        }

        [Fact]
        public async Task ObterPagamento_ReturnsExpectedPagamento()
        {
            // Arrange
            var pagamentoId = 1;
            var pagamento = new Pagamento(1, 2, StatusPagamento.Aprovado);
            _mockRepository.Setup(repo => repo.Obter(pagamentoId)).ReturnsAsync(pagamento);

            // Act
            var result = await _service.ObterPagamento(pagamentoId);

            // Assert
            Assert.Equal(pagamento, result);
            _mockRepository.Verify(repo => repo.Obter(pagamentoId), Times.Once);
        }

        [Fact]
        public async Task ObterPagamentos_ReturnsExpectedPagamentos()
        {
            // Arrange
            var pagamentos = new List<Pagamento>
            {
                new Pagamento(1, 2, StatusPagamento.Aprovado),
                new Pagamento(1, 2, StatusPagamento.Aprovado)
            }.AsQueryable();
            _mockRepository.Setup(repo => repo.Obter()).ReturnsAsync(pagamentos);

            // Act
            var result = await _service.ObterPagamento();

            // Assert
            Assert.Equal(pagamentos, result);
            _mockRepository.Verify(repo => repo.Obter(), Times.Once);
        }

        [Fact]
        public async Task ObterPagamentoPorPedido_ReturnsExpectedPagamentos()
        {
            // Arrange
            var pedidoId = 1;
            var pagamentos = new List<Pagamento>
            {
                new Pagamento(1, 2, StatusPagamento.Aprovado),
                new Pagamento(1, 2, StatusPagamento.Aprovado)
            }.AsQueryable();
            _mockRepository.Setup(repo => repo.ObterPorPedido(pedidoId)).ReturnsAsync(pagamentos);

            // Act
            var result = await _service.ObterPagamentoPorPedido(pedidoId);

            // Assert
            Assert.Equal(pagamentos, result);
            _mockRepository.Verify(repo => repo.ObterPorPedido(pedidoId), Times.Once);
        }

        [Fact]
        public async Task RemoverPagamento_CallsDeleteMethod_WithCorrectParameters()
        {
            // Arrange
            var pagamentoId = 1;
            _mockRepository.Setup(repo => repo.Remover(pagamentoId)).Returns(Task.CompletedTask);

            // Act
            await _service.RemoverPagamento(pagamentoId);

            // Assert
            _mockRepository.Verify(repo => repo.Remover(pagamentoId), Times.Once);
        }
    }
}