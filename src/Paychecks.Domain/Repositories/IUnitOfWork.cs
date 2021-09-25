using System.Threading.Tasks;

namespace Paychecks.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
    }
}