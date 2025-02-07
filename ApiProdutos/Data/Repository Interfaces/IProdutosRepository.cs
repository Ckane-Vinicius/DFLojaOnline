using ApiProdutos.Domain.Entities;

namespace ApiProdutos.Data.Repository_Interfaces
{
    public interface IProdutosRepository<T>
    {
        IEnumerable<Produtos> GetAll();
        IEnumerable<Produtos> GetByName(string Nome);
        Produtos GetById(int Id);
        void Add(Produtos entity);
        void Update(Produtos entity);
        void Delete(Produtos entity);

    }
}
