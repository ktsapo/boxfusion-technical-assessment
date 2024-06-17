namespace Employees.Domain.Aggregates.EmployeeAggregate.ValueObjects
{
    /// <summary>
    /// Value object to represent the unique identifier of an employee.
    /// </summary>
    public class EmployeeId
    {
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Value object constructor.
        /// </summary>
        /// <param name="value"></param>
        public EmployeeId(string value)
        {
            Value = value;
        }
        private EmployeeId()
        {

        }

        /// <summary>
        /// Creates the EmployeeId value object from a given string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EmployeeId Create(string value)
        {
            return new(value);
        }

        /// <summary>
        /// Generates a EmployeeId value object from a unique string.
        /// </summary>
        /// <returns></returns>
        public static EmployeeId CreateUnique()
        {
            // TODO: Implement unique id generation using the following rules:
            // 1. The id should be a string with 2 random uppercase letters followed by 4 random numbers.
            return new(Guid.NewGuid().ToString());
        }
    }
}
