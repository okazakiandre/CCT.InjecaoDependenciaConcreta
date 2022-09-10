using CCT.InjecaoDependenciaConcreta.Api.Domain;

namespace CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories
{
    public interface IProdutoRepository
    {
        Produto ObterProduto(int idProduto);
    }
}
