using Admin.Business.Interfaces;
using Admin.Business.Models;
using Admin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Data.Repository
{
    public abstract class Repository<IEntity> : IRepository<IEntity> where IEntity : Entity, new()
    {
        protected readonly AdminDbContext _dbContext;
        protected readonly DbSet<IEntity> _dbSet;

        protected Repository(AdminDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<IEntity>();
        }

        public virtual async Task Add(IEntity entity)
        {
           _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            _dbSet.Remove(new IEntity { Id = id});
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<IEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IEntity>> Search(Expression<Func<IEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(IEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
