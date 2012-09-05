namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    public interface IJoinType<T>
    {
        ISelectQuery<T> Inner<TU>();
        ISelectQuery<T> Left<TU>();
        ISelectQuery<T> LeftOuter<TU>();
        ISelectQuery<T> Right<TU>();
        ISelectQuery<T> RightOuter<TU>();
        ISelectQuery<T> Cross<TU>();
    }
}
