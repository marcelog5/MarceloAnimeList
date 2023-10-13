﻿using CarRare.Commom.DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRare.Commom.ApplicationLayer.Data
{
    public abstract class EntityFrameworkRepository<TEntity, TIdType> : IRepository<TEntity, TIdType>
        where TEntity : class
        where TIdType : struct
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(TIdType id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(TIdType id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            if (entity == null)
                return false;

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
