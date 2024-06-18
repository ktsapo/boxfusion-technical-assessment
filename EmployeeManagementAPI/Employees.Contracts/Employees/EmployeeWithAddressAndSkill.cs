namespace Employees.Contracts.Employees
{
    public record EmployeeWithAddressAndSkill(
        string EmployeeId,
        string FirstName,
        string LastName,
        string Email,
        string ContactNumber,
        DateTime DateOfBirth,
        AddressResponse Address,
        List<SkillResponse> Skills
    );
}
