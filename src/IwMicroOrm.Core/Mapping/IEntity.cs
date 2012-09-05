namespace IwMicroOrm.Core.Mapping
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}
