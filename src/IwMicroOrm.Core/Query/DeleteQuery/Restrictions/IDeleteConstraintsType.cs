using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.DeleteQuery.Restrictions
{
    public interface IDeleteConstraintsType<T>
    {
        ILogicalDeleteConstraints<T> Equal(object value);
        ILogicalDeleteConstraints<T> NotEqual(object value);
        ILogicalDeleteConstraints<T> Greater(object value);
        ILogicalDeleteConstraints<T> GreaterOrEqual(object value);
        ILogicalDeleteConstraints<T> Less(object value);
        ILogicalDeleteConstraints<T> LessOrEqual(object value);
        ILogicalDeleteConstraints<T> In(object value);
        ILogicalDeleteConstraints<T> In<TU>(ISubQuery<TU> subQuery);
        ILogicalDeleteConstraints<T> NotIn(object value);
        ILogicalDeleteConstraints<T> NotIn<TU>(ISubQuery<TU> subQuery);
        ILogicalDeleteConstraints<T> Like(string pattern);
        ILogicalDeleteConstraints<T> NotLike(string pattern);
        ILogicalDeleteConstraints<T> Between<TU>(TU begin, TU end);
        ILogicalDeleteConstraints<T> NotBetween<TU>(TU begin, TU end);
        ILogicalDeleteConstraints<T> IsNull();
        ILogicalDeleteConstraints<T> IsNotNull();
    }
}
