using ApiProdutos.Data.Context;
using ApiProdutos.Data.Repository_Interfaces;
using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data.Repository
{
    public class ProdutosRepository : IProdutosRepository<Produtos>
    {
        private readonly ApiContext _context;
        protected DbSet<Produtos> DbSet;

        public ProdutosRepository(ApiContext context) { _context = context; DbSet = context.Set<Produtos>(); }

        public IEnumerable<Produtos> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public IEnumerable<Produtos> GetByName(string Nome)
        {
            return _context.Produtos.Where(x => Nome.Contains(x.Nome));
        }

        public Produtos GetById(int Id)
        {
            return _context.Produtos.Where(x => x.Id == Id).FirstOrDefault();
        }

        public virtual void Add(Produtos entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(Produtos entity)
        {
            DbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Produtos entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
