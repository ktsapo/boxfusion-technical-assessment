using Employees.Domain.Aggregates.EmployeeAggregate.ValueObjects;
using Employees.Domain.Interfaces;

namespace Employees.Domain.Aggregates.EmployeeAggregate.Repository
{
    public interface IEmployeeRepository: IBaseRepository<Employee, EmployeeId>
    {
    }
}
