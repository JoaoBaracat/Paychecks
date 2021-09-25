using Paychecks.Domain.Entities;
using Paychecks.Domain.Repositories;
using Paychecks.Infra.Data.Contexts;

namespace Paychecks.Infra.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PaychecksDbContext context) : base(context)
        {
        }
    }
}