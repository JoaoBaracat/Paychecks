using Paychecks.Domain.Repositories;
using Paychecks.Infra.Data.Contexts;
using System.Threading.Tasks;

namespace Paychecks.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaychecksDbContext _context;

        public UnitOfWork(PaychecksDbContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}