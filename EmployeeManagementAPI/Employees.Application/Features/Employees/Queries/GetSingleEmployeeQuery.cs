using Employees.Contracts.Employees;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    public record GetSingleEmployeeQuery(string Id) : IRequest<EmployeeWithAddressAndSkill>;
}
