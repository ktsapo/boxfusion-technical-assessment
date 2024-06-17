namespace Employees.Domain.Common.Models
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            Id = id;
        }
    }
}
