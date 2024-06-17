namespace Employees.Contracts.Employees
{
    public record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string Email,
        string ContactNumber,
        DateTime DateOfBirth,
        CreateAddressRequest Address,
        List<CreateEmployeeSkillRequest> Skills
    );
}
