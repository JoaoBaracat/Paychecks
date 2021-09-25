using Microsoft.EntityFrameworkCore;
using Paychecks.Domain.Entities;
using Paychecks.Domain.Repositories;
using Paychecks.Infra.Data.Contexts;
using System;
using System.Threading.Tasks;

namespace Paychecks.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DbSet<TEntity> _entities;

        protected Repository(PaychecksDbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public void CreateAsync(TEntity entity)
        {
            _entities.Add(entity);
        }
    }
}