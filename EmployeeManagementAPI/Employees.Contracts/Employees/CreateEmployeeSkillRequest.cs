namespace Employees.Contracts.Employees
{
    public record CreateEmployeeSkillRequest(
        string Name,
        int YearsOfExperience,
        int Rating
    );
}