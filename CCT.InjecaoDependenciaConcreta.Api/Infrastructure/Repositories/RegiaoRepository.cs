namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        public double ObterFreteRegiao(int numeroCep)
        {
            if (numeroCep >= 0 && numeroCep < 10000000)
            {
                return 5.0;
            }
            else if (numeroCep >= 10000000 && numeroCep < 50000000)
            {
                return 15.0;
            }
            else if (numeroCep >= 50000000 && numeroCep < 80000000)
            {
                return 30.0;
            };
            return 50.0;
        }
    }
}
