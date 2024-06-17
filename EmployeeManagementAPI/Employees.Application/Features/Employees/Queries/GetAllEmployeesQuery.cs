using Employees.Contracts.Employees;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    public record GetAllEmployeesQuery(): IRequest<List<EmployeeResponse>>;
}
