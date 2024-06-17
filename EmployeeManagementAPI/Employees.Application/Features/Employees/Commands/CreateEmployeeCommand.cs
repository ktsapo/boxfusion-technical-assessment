using Employees.Contracts.Employees;
using MediatR;

namespace Employees.Application.Features.Employees.Commands
{
    /// <summary>
    /// Command for creating an employee
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="ContactNumber"></param>
    /// <param name="DateOfBirth"></param>
    /// <param name="Address"></param>
    public record CreateEmployeeCommand(
        string FirstName,
        string LastName,
        string Email,
        string ContactNumber,
        DateTime DateOfBirth,
        CreateAddressRequest Address,
        List<CreateEmployeeSkillRequest> skills
    ): IRequest;
}
