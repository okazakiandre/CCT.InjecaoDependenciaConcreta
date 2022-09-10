using CCT.InjecaoDependenciaConcreta.Api.Domain;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices
{
    public interface IClienteApiClient
    {
        Task<Cliente> ObterClienteAsync(long cpfCnpj);
    }
}
