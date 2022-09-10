using CCT.InjecaoDependenciaConcreta.Api.Exceptions;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices
{
    public class ApiProxy
    {
        public T ExecutarChamada<T>(string url)
        {
            using var apiCli = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            var response = apiCli.GetFromJsonAsync<T>("").Result;
            if (response is null)
            {
                throw new ExternalServiceException("Cliente não cadastrado.");
            }
            return response;
        }
    }
}
