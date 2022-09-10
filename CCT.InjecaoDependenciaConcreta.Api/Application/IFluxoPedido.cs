using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Requests;

namespace CCT.InjecaoDependenciaConcreta.Api.Application
{
    public interface IFluxoPedido
    {
        Task<Pedido> CalcularPedido(List<ProdutoPedido> produtos,
                                    long cpfCliente);
    }
}
