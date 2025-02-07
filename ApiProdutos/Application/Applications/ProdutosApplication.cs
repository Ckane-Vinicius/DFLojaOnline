using ApiProdutos.Application.Application_Interfaces;
using ApiProdutos.Domain.Entities;
using ApiProdutos.Domain.Services_Interfaces;
using ApiProdutos.DTO;

namespace ApiProdutos.Application.Applications
{
    public class ProdutosApplication : IProdutosApplication
    {
        private readonly IProdutoServices<Produtos> _produtosServices;

        public ProdutosApplication(IProdutoServices<Produtos> produtosServices)
        {
            _produtosServices = produtosServices;
        }

        public async Task<IEnumerable<Produtos>> GetAllItemsAsync()
        {
            return await Task.Run(() => { return _produtosServices.GetAll(); });
        }

        public async Task<string> GetItemCountAsync()
        {
            return await Task.Run(() => {

                var produtos = _produtosServices.GetAll();

                var contagem = $"Existem o total de {produtos.Count()} registros.";

                return contagem;
            });
        }

        public async Task<IEnumerable<Produtos>> GetItemsByNameAsync(string Nome)
        {
            return await Task.Run(() => { return _produtosServices.GetByName(Nome); });
        }

        public async Task<Produtos> GetItemByIdAsync(int idProduto)
        {
            return await Task.Run(() => { return _produtosServices.GetById(idProduto); });
        }
        
        public async Task<string> CreateItemAsync(ProdutosRequets dto)
        {
            return await Task.Run(() => {

                try
                {
                    var verificarnome = _produtosServices.GetByName(dto.Nome);

                    if (verificarnome == null)
                        return "Já existe um produto com esse nome";

                    var novoProdutos = new Produtos { Nome = dto.Nome, Quantidade = dto.Quantidade, DataCriacao = DateTime.Now, Ativo = true };

                    _produtosServices.Add(novoProdutos);

                    return "Criado com sucesso.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
               
            });
        }

        public async Task<string> UpdateItemAsync(int id, ProdutosRequets dto)
        {
            return await Task.Run(() => {
               
                try
                {
                    var produto = _produtosServices.GetById(id);

                    produto.Quantidade = dto.Quantidade;
                    produto.Nome = dto.Nome;

                    _produtosServices.Update(produto);

                    return "Produto atualizado com sucesso.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }                
            });
        }

        public async Task<string> DeleteItemAsync(int id)
        {
            return await Task.Run(() => {

                var produto = _produtosServices.GetById(id);

                _produtosServices.Delete(produto);

                return "Produto removido.";               
            });
        }
    }
}
