using Paychecks.Domain.Apps;
using Paychecks.Domain.Entities;
using Paychecks.Domain.Entities.Validations;
using Paychecks.Domain.Notifications;
using Paychecks.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Paychecks.App.Apps
{
    public class EmployeeApp : AppBase, IEmployeeApp
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeApp(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, INotifier notifier) : base(unitOfWork, notifier)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                Notify($"The employee {id} was not found.");
                return null;
            }

            return employee;
        }

        public async Task<Guid> CreateAsync(Employee employee)
        {
            if (!Validate(new EmployeeValidation(), employee))
            {
                return Guid.Empty;
            }
            _employeeRepository.CreateAsync(employee);
            await UnitOfWork.Save();
            return employee.Id;
        }
    }
}