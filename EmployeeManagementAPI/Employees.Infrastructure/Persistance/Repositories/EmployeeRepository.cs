using Employees.Contracts.Employees;
using Employees.Domain.Employees;
using Employees.Domain.Employees.Repository;
using Employees.Domain.Employees.ValueObjects;
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
        public async Task DeleteAsync(Employee entity)
        {
            _employeeDbContext.Remove(entity);
            await _employeeDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get a list of employees from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeDbContext.Employees
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get a list of employees without their skills or addresses.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeResponse>> GetAllWithoutSkillsAsync()
        {
            return await _employeeDbContext.Employees
                .AsNoTracking()
                .Select(e => new EmployeeResponse(e.Id.Value,
                    e.FirstName,
                    e.LastName,
                    e.Email,
                    e.ContactNumber,
                    e.DateOfBirth))
                .ToListAsync();
        }

        /// <summary>
        /// Get a single employee by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee?> GetByIdAsync(EmployeeId id)
        {
            return await _employeeDbContext.Employees
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<List<SkillResponse>> GetEmployeeSkills(EmployeeId employeeId)
        {

            var skills = await _employeeDbContext.Employees
                .AsNoTracking()
                .Where(e => e.Id == employeeId) 
                .SelectMany(e => e.Skills)
                .ToListAsync();
            
            return skills.Select(s => 
            new SkillResponse(s.Name, s.YearsOfExperience, s.SeniorityRating.ToString()))
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeWithAddress?> GetEmployeeWithAddress(EmployeeId employeeId)
        {
            return await _employeeDbContext.Employees
                .AsNoTracking()
                .Where(e => e.Id == employeeId)
                .Select(e => new EmployeeWithAddress(e.Id.Value,
                    e.FirstName,
                    e.LastName,
                    e.Email,
                    e.ContactNumber,
                    e.DateOfBirth,
                    new AddressResponse(
                       e.Address.City,
                        e.Address.PostalCode,
                        e.Address.Country
                    )))
                .FirstOrDefaultAsync();
        }


        /// <summary>
        /// Search for an employee using either their first name, last name, or email.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeResponse>> Search(string searchQuery)
        {
            var employees = _employeeDbContext.Employees
                .AsNoTracking()
                .Where(e => e.FirstName.Contains(searchQuery) || e.LastName.Contains(searchQuery) ||
                                                                                  e.Email.Contains(searchQuery))
                .Select(e => new EmployeeResponse(
                                    e.Id.Value,
                                    e.FirstName,
                                    e.LastName,
                                    e.Email,
                                    e.ContactNumber,
                                    e.DateOfBirth
                ));

            return await employees.ToListAsync();
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
