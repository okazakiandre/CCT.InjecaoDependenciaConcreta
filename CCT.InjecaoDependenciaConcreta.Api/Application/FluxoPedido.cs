using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories;
using CCT.InjecaoDependenciaConcreta.Api.Requests;

namespace CCT.InjecaoDependenciaConcreta.Api.Application
{
    public class FluxoPedido
    {
        private ProdutoRepository ProdRepo { get; }
        private FluxoFrete FlxFrete { get; }
        private ClienteApiClient CliApi { get; }

        public FluxoPedido(ProdutoRepository prodRepo,
                           FluxoFrete flxFrete,
                           ClienteApiClient cliApi)
        {
            ProdRepo = prodRepo;
            FlxFrete = flxFrete;
            CliApi = cliApi;
        }

        public Pedido CalcularPedido(List<ProdutoPedido> produtos,
                                     long cpfCliente)
        {
            var cliente = CliApi.ObterCliente(cpfCliente);
            var ped = new Pedido
            {
                CpfCliente = cliente.NumeroCpf,
                NomeCliente = cliente.Nome
            };

            foreach (var prodPed in produtos)
            {
                var prod = ProdRepo.ObterProduto(prodPed.IdProduto);

                var valorFrete = 0.0;
                if (!prod.TemPromocaoFreteGratis)
                {
                    valorFrete = FlxFrete.CalcularFrete(cpfCliente,
                                                        prod.Peso);
                }

                ped.Produtos.Add(prodPed);
                ped.ValorTotal += prod.Preco * prodPed.Quantidade;
                ped.ValorFrete += valorFrete;
            }

            ped.ValorTotal += ped.ValorFrete;
            return ped;
        }
    }
}
