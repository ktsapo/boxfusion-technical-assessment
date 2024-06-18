using Employees.Contracts.Employees;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Interfaces;

namespace Employees.Domain.Employees.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeId>
    {
        /// <summary>
        /// Search for an employee using either their first name, last name, or email.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<EmployeeResponse>> Search(string searchQuery);

        /// <summary>
        /// Get list of employees without their skills
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeResponse>> GetAllWithoutSkillsAsync();

        /// <summary>
        /// Retrieve an employee's skills.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<List<SkillResponse>> GetEmployeeSkills(EmployeeId employeeId);

        /// <summary>
        /// Get an employee along with their address.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<EmployeeWithAddress?> GetEmployeeWithAddress(EmployeeId employeeId);

    }
}
