using WebApp.Common.Interfaces;

namespace WebApp.Common 
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
        public virtual bool Active { get; set; }
    }
}
