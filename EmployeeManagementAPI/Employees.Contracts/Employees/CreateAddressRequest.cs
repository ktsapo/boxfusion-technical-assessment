namespace Employees.Contracts.Employees
{
    public record CreateAddressRequest(
            string City,
            string PostalCode,
            string Country
    );
}
