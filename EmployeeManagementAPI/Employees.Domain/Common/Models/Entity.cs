namespace Employees.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            Id = id;
        }

        public bool Equals(Entity<TId>? other)
        {
            return Id != null && other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id != null && Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            if (Id != null)
                return Id.GetHashCode();

            return base.GetHashCode();
        }
    }
}
