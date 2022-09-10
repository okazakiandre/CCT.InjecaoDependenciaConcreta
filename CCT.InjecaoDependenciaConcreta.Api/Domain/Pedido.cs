using CCT.InjecaoDependenciaConcreta.Api.Requests;

namespace CCT.InjecaoDependenciaConcreta.Api.Domain
{
    public class Pedido
    {
        public List<ProdutoPedido> Produtos { get; set; }
        public double ValorFrete { get; set; }
        public double ValorTotal { get; set; }
        public long CpfCliente { get; set; }
        public string NomeCliente { get; set; }

        public Pedido()
        {
            Produtos = new List<ProdutoPedido>();
        }
    }
}
