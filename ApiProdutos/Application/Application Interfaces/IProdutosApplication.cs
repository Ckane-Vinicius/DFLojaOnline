using ApiProdutos.Domain.Entities;
using ApiProdutos.DTO;

namespace ApiProdutos.Application.Application_Interfaces
{
    public interface IProdutosApplication
    {
        Task<IEnumerable<Produtos>> GetAllItemsAsync();
        Task<string> GetItemCountAsync();
        Task<IEnumerable<Produtos>> GetItemsByNameAsync(string Nome);
        Task<Produtos> GetItemByIdAsync(int idProduto);
        Task<string> CreateItemAsync(ProdutosRequets dto);
        Task<string> UpdateItemAsync(int id, ProdutosRequets dto);
        Task<string> DeleteItemAsync(int id);
    }
}
