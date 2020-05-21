namespace WebApp.Common.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool Active { get; set; }
    }
}
