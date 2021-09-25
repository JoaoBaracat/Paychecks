using Paychecks.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Paychecks.Domain.Apps
{
    public interface IApp<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(TEntity entity);
    }
}