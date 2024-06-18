using Employees.Domain.Common.Models;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Skills;

namespace Employees.Domain.Employees
{
    /// <summary>
    /// Entity to manage employees in the system.
    /// </summary>
    public class Employee : Entity<EmployeeId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Address Address { get; private set; }

        private readonly List<EmployeeSkill> _skills = new();
        public IReadOnlyList<EmployeeSkill> Skills => _skills.AsReadOnly();

        private Employee(EmployeeId employeeId, string firstName, string lastName, string email, string contactNumber, DateTime dateOfBirth, Address address, List<EmployeeSkill> skills) : base(employeeId)
        {

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            DateOfBirth = dateOfBirth;
            Address = address;
            _skills = skills;
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
        /// <param name="address"></param>
        /// <param name="skills"></param>
        /// <returns></returns>
        public static Employee Create(string firstName, string lastName, string email, string contactNumber, DateTime dateOfBirth, Address address, List<EmployeeSkill> skills)
        {
            return new(EmployeeId.CreateUnique(), firstName, lastName, email, contactNumber, dateOfBirth, address, skills);
        }


        public override bool Equals(object? obj)
        {
            return obj != null && obj is Employee e && Id == e.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
