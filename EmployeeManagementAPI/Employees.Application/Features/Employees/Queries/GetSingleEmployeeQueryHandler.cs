using Employees.Contracts.Employees;
using Employees.Domain.Employees;
using Employees.Domain.Employees.Repository;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Exceptions;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    /// <summary>
    /// Query handler for retrieving a single employee along with their address and skills.
    /// </summary>
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQuery, EmployeeWithAddressAndSkill>
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// 
        /// </summary>
        public GetSingleEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotfoundException"></exception>
        public async Task<EmployeeWithAddressAndSkill> Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeeSkills = await _employeeRepository.GetEmployeeSkills(EmployeeId.Create(request.Id));
            var employee = await _employeeRepository.GetEmployeeWithAddress(EmployeeId.Create(request.Id));

            if (employee == null)
            {
                throw new NotfoundException(nameof(Employee), request.Id);
            }

            return new EmployeeWithAddressAndSkill(
                employee.EmployeeId,
                employee.FirstName,
                employee.LastName,
                employee.Email,
                employee.ContactNumber,
                employee.DateOfBirth,
                new AddressResponse(
                    employee.Address.City,
                    employee.Address.PostalCode,
                    employee.Address.Country
                ),
               employeeSkills
            );
        }
    }
}
