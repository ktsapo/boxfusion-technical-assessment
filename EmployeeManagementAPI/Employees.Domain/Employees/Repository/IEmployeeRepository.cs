using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Interfaces;

namespace Employees.Domain.Employees.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeId>
    {
    }
}
