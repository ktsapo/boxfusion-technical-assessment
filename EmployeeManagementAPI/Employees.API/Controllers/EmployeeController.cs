using Employees.Application.Features.Employees.Commands;
using Employees.Application.Features.Employees.Queries;
using Employees.Contracts.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Http method to get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var query = new GetAllEmployeesQuery();
           var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Http method to create an employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var command = new CreateEmployeeCommand(request.FirstName, request.LastName, request.Email, request.ContactNumber, request.DateOfBirth, request.Address, request.Skills);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Http method to search for an employee by email, first name, or last name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("Search"), HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var command = new SearchEmployeeQuery(query);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}"), HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var command = new GetSingleEmployeeQuery(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
