using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Paychecks.Api.Models.Employee;
using Paychecks.Domain.Apps;
using Paychecks.Domain.Entities;
using Paychecks.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace Paychecks.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmployeeController : MainController
    {
        private readonly IEmployeeApp _employeeApp;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeApp employeeApp, IMapper mapper, ILogger<EmployeeController> logger, INotifier notifier)
             : base(notifier, logger)
        {
            _employeeApp = employeeApp;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get a employee
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>An ActionResult of type ResposnseEmployeeQuery</returns>
        /// <response code="404">Employee not found</response>
        [HttpGet("{id}", Name = "GetEmployeeByIdAsync")]
        [ProducesResponseType(typeof(ResposnseEmployeeQuery), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResposnseEmployeeQuery>> GetEmployeeByIdAsync(Guid id)
        {
            _logger.LogInformation($"Request for employee with id: {id}");
            var employee = await _employeeApp.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound(id);
            }

            return CustomResponse(_mapper.Map<ResposnseEmployeeQuery>(employee));
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <returns>An ActionResult of type ResponseEmployeeQuery</returns>
        /// <response code="400">The command object did not pass the validation</response>
        [HttpPost(Name = "CreateEmployeeAsync")]
        [ProducesResponseType(typeof(ResponseEmployeeId), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseEmployeeId>> CreateEmployeeAsync(CreateEmployeeCommand createEmployeeCommand)
        {
            _logger.LogInformation($"Request to create new employee with: {JsonConvert.SerializeObject(createEmployeeCommand)}");
            if (!IsModelValid())
            {
                return CustomResponse(createEmployeeCommand);
            }
            return CustomResponse(new ResponseEmployeeId { Id = await _employeeApp.CreateAsync(_mapper.Map<Employee>(createEmployeeCommand)) });
        }
    }
}