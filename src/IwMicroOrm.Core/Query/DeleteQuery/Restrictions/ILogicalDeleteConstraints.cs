namespace IwMicroOrm.Core.Query.DeleteQuery.Restrictions
{
    public interface ILogicalDeleteConstraints<T> : IDeleteQuery<T>
    {
        IDeleteQuery<T> Or { get; }
        IDeleteQuery<T> And { get; }
    }
}
