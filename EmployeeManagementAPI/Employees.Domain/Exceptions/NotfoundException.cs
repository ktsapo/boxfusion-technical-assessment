namespace Employees.Domain.Exceptions
{
    public class NotfoundException: Exception
    {
        public NotfoundException(string message): base(message)
        {
        }

        public NotfoundException(string entityName, string id): base($"{entityName} with id {id} was not found.")
        {
        }
    }
}
