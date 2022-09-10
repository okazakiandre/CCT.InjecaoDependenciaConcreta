using CCT.InjecaoDependenciaConcreta.Api.Application;
using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories;
using CCT.InjecaoDependenciaConcreta.Api.Requests;
using Moq;

namespace CCT.InjecaoDependenciaConcreta.UnitTest
{
    [TestClass]
    public class FluxoPedidoTest
    {
        [TestMethod]
        public void DeveriaCalcularPedidoSemProdutosComNomeDoCliente()
        {
            var lista = new List<ProdutoPedido>();
            var cliente = new Cliente { Nome = "cliente teste" };
            var mockProd = new Mock<ProdutoRepository>();
            var mockFrete = new Mock<FluxoFrete>();
            var mockCli = new Mock<ClienteApiClient>();
            mockCli.Setup(m => m.ObterCliente(It.IsAny<long>())).Returns(cliente);
            var flx = new FluxoPedido(mockProd.Object, 
                                      mockFrete.Object,
                                      mockCli.Object);

            var res = flx.CalcularPedido(lista, 1);

            Assert.AreEqual("cliente teste", res.NomeCliente);
        }
    }
}