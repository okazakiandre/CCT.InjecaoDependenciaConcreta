namespace CCT.InjecaoDependenciaConcreta.Api.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException(string msg)
            : base(msg)
        {
        }

        public ExternalServiceException()
            : base()
        {
        }
    }
}
