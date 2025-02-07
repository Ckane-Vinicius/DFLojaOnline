
using ApiProdutos.Data.Repository_Interfaces;
using ApiProdutos.Domain.Entities;
using ApiProdutos.Domain.Services_Interfaces;

namespace ApiProdutos.Domain.Services
{
    public class ProdutosServices : IProdutoServices<Produtos>
    {
        private readonly IProdutosRepository<Produtos> _produtosRepository;

        public ProdutosServices(IProdutosRepository<Produtos> produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public IEnumerable<Produtos> GetAll()
        {
            return _produtosRepository.GetAll();
        }

        public IEnumerable<Produtos> GetByName(string nome)
        {
            return _produtosRepository.GetByName(nome);
        }

        public Produtos GetById(int id)
        {
            return _produtosRepository.GetById(id);
        }

        public void Add(Produtos entity)
        {
            _produtosRepository.Add(entity);
        }

        public void Update(Produtos entity)
        {
            _produtosRepository.Update(entity);
        }

        public void Delete(Produtos entity)
        {
            _produtosRepository.Delete(entity);
        }
    }
}
