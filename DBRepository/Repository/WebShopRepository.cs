using DBRepository.Contexts;
using DBRepository.Interfaces;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class WebShopRepository<TEntity> : IRepository<TEntity> where TEntity : ItemBase
    {
        internal WebShopDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public WebShopRepository()
        {
            _context = new WebShopDbContext();
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
            return Get(item.Id);
        }

        public void Delete(int Id)
        {
            TEntity EntityToDelete = _dbSet.Find(Id);
            _dbSet.Remove(EntityToDelete);
            _context.SaveChanges();
        }

        public TEntity Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        ~WebShopRepository()
        {
            _context.Dispose();
        }
    }
}
