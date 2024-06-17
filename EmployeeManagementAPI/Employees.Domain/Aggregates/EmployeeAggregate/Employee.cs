using Employees.Domain.Aggregates.EmployeeAggregate.ValueObjects;
using Employees.Domain.Common.Models;

namespace Employees.Domain.Aggregates.EmployeeAggregate
{
    /// <summary>
    /// Entity to manage employees in the system.
    /// </summary>
    public class Employee: Entity<EmployeeId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        private Employee(EmployeeId employeeId, string firstName, string lastName, string email, string contactNumber, DateTime dateOfBirth): base(employeeId)
        {

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            DateOfBirth = dateOfBirth;
        }

        private Employee()
        {
        }

        /// <summary>
        /// Generate a new Employee entity from the given parameters.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="contactNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static Employee Create(string firstName, string lastName, string email, string contactNumber, DateTime dateOfBirth)
        {
            return new(EmployeeId.CreateUnique(), firstName, lastName, email, contactNumber, dateOfBirth);
        }
    }
}
