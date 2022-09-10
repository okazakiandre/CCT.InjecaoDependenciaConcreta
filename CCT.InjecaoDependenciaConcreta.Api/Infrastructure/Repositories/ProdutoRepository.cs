using CCT.InjecaoDependenciaConcreta.Api.Domain;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto ObterProduto(int idProduto) =>
            idProduto switch
            {
                1 => new Produto(1, 250.0, 10.0, true),
                2 => new Produto(2, 2500.0, 20.0, false),
                3 => new Produto(3, 100.0, 35.0, false),
                _ => new Produto(4, 2100.0, 12.2, true)
            };
    }
}
