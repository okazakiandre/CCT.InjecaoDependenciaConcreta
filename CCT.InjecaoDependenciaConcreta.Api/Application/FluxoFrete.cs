using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories;

namespace CCT.InjecaoDependenciaConcreta.Api.Application
{
    public class FluxoFrete
    {
        private RegiaoRepository RegRepo { get; }
        private ClienteApiClient CliApi { get; }

        public FluxoFrete(RegiaoRepository regRepo,
                          ClienteApiClient cliApi)
        {
            RegRepo = regRepo;
            CliApi = cliApi;
        }

        public double CalcularFrete(long cpfCliente,
                                    double pesoProduto)
        {
            const double PESO_MINIMO = 2000.0;
            const double FRETE_MINIMO = 5.5;

            var freteRegiao = 0.0;
            if (pesoProduto >= PESO_MINIMO)
            {
                var cliente = CliApi.ObterCliente(cpfCliente);
                freteRegiao = RegRepo.ObterFreteRegiao(cliente.CepEntrega);
                if (freteRegiao < FRETE_MINIMO)
                {
                    freteRegiao = FRETE_MINIMO;
                }
            }

            return freteRegiao;
        }
    }
}
