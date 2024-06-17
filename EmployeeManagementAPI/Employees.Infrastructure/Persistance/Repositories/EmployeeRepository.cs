using Employees.Domain.Aggregates.EmployeeAggregate;
using Employees.Domain.Aggregates.EmployeeAggregate.Repository;
using Employees.Domain.Aggregates.EmployeeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistance.Repositories
{
    /// <summary>
    /// Implementation of the Employee repository interface.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        /// <summary>
        /// Persist an Employee to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Employee entity)
        {
            await _employeeDbContext.AddAsync(entity);
            await _employeeDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of employees from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeDbContext.Employees.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get a single employee by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetByIdAsync(EmployeeId id)
        {
            return await _employeeDbContext.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
