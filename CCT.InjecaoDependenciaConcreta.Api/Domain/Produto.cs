namespace CCT.InjecaoDependenciaConcreta.Api.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public double Preco { get; set; }
        public bool TemPromocaoFreteGratis { get; set; }

        public Produto(int id,
                       double peso,
                       double preco,
                       bool temPromocaoFreteGratis)
        {
            Id = id;
            Peso = peso;
            Preco = preco;
            TemPromocaoFreteGratis = temPromocaoFreteGratis;
        }
    }
}
