using Employees.Contracts.Employees;
using Employees.Domain.Employees.Repository;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    /// <summary>
    /// Query to handle fetching of employees from the database
    /// </summary>
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Return a list of employees
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(employee => new EmployeeResponse(employee.Id.Value, 
                employee.FirstName, 
                employee.LastName,
                employee.Email,
                employee.ContactNumber,
                employee.DateOfBirth
            )).ToList();
        }

        
    }
}
