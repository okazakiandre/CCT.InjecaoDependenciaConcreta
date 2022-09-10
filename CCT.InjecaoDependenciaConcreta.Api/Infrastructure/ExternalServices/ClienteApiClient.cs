using CCT.InjecaoDependenciaConcreta.Api.Domain;
using CCT.InjecaoDependenciaConcreta.Api.Exceptions;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices
{
    public class ClienteApiClient
    {
        private readonly ApiProxy _proxy;
        private readonly string _urlBase;

        public ClienteApiClient(string url)
        {
            _proxy = new ApiProxy();
            _urlBase = url;
        }

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
    }
}
