using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Cliente;

[ExcludeFromCodeCoverage]
public class CadastroClienteDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Aniversario { get; set; }
}
