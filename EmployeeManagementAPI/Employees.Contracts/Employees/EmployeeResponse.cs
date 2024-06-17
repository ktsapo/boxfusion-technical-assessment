namespace Employees.Contracts.Employees
{
    public record EmployeeResponse(
        string EmployeeId,
        string FirstName,
        string LastName,
        string Email,
        string ContactNumber,
        DateTime DateOfBirth
    );
}
