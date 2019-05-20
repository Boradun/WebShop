using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    interface IRepository<TEntity> where TEntity: ItemBase
    {
        TEntity Create(TEntity entity);
        void Update(TEntity item);
        void Delete(int Id);
        TEntity Get(int Id);
        List<TEntity> GetAll();
    }
}
