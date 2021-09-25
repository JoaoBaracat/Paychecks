using Paychecks.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Paychecks.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        void CreateAsync(TEntity entity);
    }
}