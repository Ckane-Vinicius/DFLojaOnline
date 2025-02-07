namespace ApiProdutos.Domain.Entities
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }     
        public bool Ativo { get; set; }
    }
}
