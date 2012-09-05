namespace IwMicroOrm.Core.Query.SelectQuery.Restrictions
{
    public interface ILogicalSelectConstraints<T> : ISelectQuery<T>
    {
        ISelectQuery<T> Or { get; }
        ISelectQuery<T> And { get; }
    }
}
