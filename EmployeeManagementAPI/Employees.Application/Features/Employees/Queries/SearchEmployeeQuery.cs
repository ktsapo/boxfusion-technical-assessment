using Employees.Contracts.Employees;
using MediatR;

namespace Employees.Application.Features.Employees.Queries
{
    public record SearchEmployeeQuery(string searchQuery): IRequest<List<EmployeeResponse>>;
}
