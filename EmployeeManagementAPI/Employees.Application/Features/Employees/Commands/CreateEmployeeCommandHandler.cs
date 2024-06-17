using Employees.Domain.Employees;
using Employees.Domain.Employees.Repository;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Skills;
using Employees.Domain.Skills.Enums;
using MediatR;

namespace Employees.Application.Features.Employees.Commands
{
    /// <summary>
    /// Command to create an employee
    /// </summary>
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Command handler to create an employee along with address and skills
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Employee.Create(
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.ContactNumber, 
                request.DateOfBirth, 
                Address.Create(
                    request.Address.City, 
                    request.Address.PostalCode,         request.Address.Country),
                request.skills.Select(
                    s => 
                        EmployeeSkill.Create(
                            s.Name, 
                            s.YearsOfExperience, 
                            (SeniorityRating)s.Rating
                            ))
                .ToList()
                );
            await _employeeRepository.AddAsync(employee);
        }
    }
}
