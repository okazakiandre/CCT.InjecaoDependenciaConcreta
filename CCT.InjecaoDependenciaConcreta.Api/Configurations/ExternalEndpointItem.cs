namespace CCT.InjecaoDependenciaConcreta.Api.Configurations
{
    public class ExternalEndpointItem
    {
        public ExternalEndpointItem(string url, int timeout)
        {
            Url = url;
            Timeout = timeout;
        }
        public string Url { get; }
        public int Timeout { get; }
    }
}
