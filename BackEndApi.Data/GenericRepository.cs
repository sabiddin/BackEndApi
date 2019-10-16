using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndApi.Domain.Interfaces;

namespace BackEndApi.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class, IEntity
    {
        private readonly WoundExpertDataContext _dbContext;

        public GenericRepository(WoundExpertDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _dbContext.Set<TEntity>().AsNoTracking());
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            bool success = false;
            try
            {
                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                success = true;
            }
            catch (Exception ex)
            {                
            }
            return success;
        }

      
    }
}
