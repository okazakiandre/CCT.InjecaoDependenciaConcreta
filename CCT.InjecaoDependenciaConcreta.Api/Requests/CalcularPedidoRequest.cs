namespace CCT.InjecaoDependenciaConcreta.Api.Requests
{
    public record CalcularPedidoRequest(
        List<ProdutoPedido> Produtos,
        long CpfCliente
    );
}
