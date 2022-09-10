namespace CCT.InjecaoDependenciaConcreta.Api.Application
{
    public interface IFluxoFrete
    {
        Task<double> CalcularFrete(long cpfCliente,
                                   double pesoProduto);
    }
}
