namespace CCT.InjecaoDependenciaConcreta.Api.Configurations
{
    public interface IExternalEndpoints
    {
        ExternalEndpointItem GetItem(string endpointName);
    }
}
