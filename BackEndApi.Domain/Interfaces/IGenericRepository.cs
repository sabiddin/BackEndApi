using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndApi.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
         where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task<bool> Delete(int id);
    }
}
