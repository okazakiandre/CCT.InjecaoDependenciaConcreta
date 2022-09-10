using CCT.InjecaoDependenciaConcreta.Api.Application;
using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CCT.InjecaoDependenciaConcreta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private IFluxoPedido FlxPed { get; }

        public PedidosController(IFluxoPedido flxPed)
        {
            FlxPed = flxPed;
        }

        [HttpPost("calculo")]
        public async Task<Pedido> CalcularPedido(CalcularPedidoRequest req)
        {
            var pedido = await FlxPed.CalcularPedido(req.Produtos, req.CpfCliente);
            return pedido;
        }
    }
}