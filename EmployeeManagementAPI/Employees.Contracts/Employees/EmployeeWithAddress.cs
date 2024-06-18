namespace Employees.Contracts.Employees
{
    public record EmployeeWithAddress(
        string EmployeeId,
        string FirstName,
        string LastName,
        string Email,
        string ContactNumber,
        DateTime DateOfBirth,
        AddressResponse Address
    );
}
