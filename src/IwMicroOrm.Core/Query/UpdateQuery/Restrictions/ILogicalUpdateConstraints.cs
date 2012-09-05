namespace IwMicroOrm.Core.Query.UpdateQuery.Restrictions
{
    public interface ILogicalUpdateConstraints<T> : IUpdateQuery<T>
    {
        IUpdateQuery<T> Or { get; }
        IUpdateQuery<T> And { get; }
    }
}
