namespace Employees.Contracts.Employees
{
    public record AddressResponse(
        string City,
        string PostalCode,
        string Country
    );
}
