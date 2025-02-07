using Newtonsoft.Json;

namespace ApiProdutos.DTO
{
    public class ProdutosRequets
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }
}
