using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Exceptions;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices
{
    public class ClienteApiClientRetro : IClienteApiClient
    {
        private readonly ApiProxy _proxy;
        private readonly string _urlBase;
        private HttpClient ApiCli { get; }

        public ClienteApiClientRetro(string url)
        {
            _proxy = new ApiProxy();
            _urlBase = url;
        }

        public ClienteApiClientRetro(HttpClient cli)
        {
            ApiCli = cli;
        }

        [Obsolete("Este método não deve ser usado, remova assim que possível.")]
        public Cliente ObterCliente(long cpfCnpj)
        {
            var url = $"{_urlBase}clientes/{cpfCnpj}";
            var cliente = _proxy.ExecutarChamada<Cliente>(url);
            if (cliente is null)
            {
                throw new ExternalServiceException("Cliente não cadastrado.");
            }
            return cliente;
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
