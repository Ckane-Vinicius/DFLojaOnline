using ApiProdutos.Domain.Entities;
using System.Linq.Expressions;

namespace ApiProdutos.Domain.Services_Interfaces
{
    public interface IProdutoServices<TEntity>
    {
        IEnumerable<Produtos> GetAll();
        IEnumerable<Produtos> GetByName(string nome);
        Produtos GetById(int id);
        void Add(TEntity entity);        
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
