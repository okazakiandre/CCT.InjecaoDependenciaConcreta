using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Exceptions;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices
{
    public class ClienteApiClientRefat : IClienteApiClient
    {
        private HttpClient ApiCli { get; }

        public ClienteApiClientRefat(HttpClient cli)
        {
            ApiCli = cli;
        }

        public async Task<Cliente> ObterClienteAsync(long cpfCnpj)
        {
            var cliente = await ApiCli.GetFromJsonAsync<Cliente>($"clientes/{cpfCnpj}");
            if (cliente is null)
            {
                throw new ExternalServiceException("Cliente não cadastrado.");
            }
            return cliente;
        }
    }
}
