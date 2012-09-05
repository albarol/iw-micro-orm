using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.UpdateQuery.Restrictions
{
    public interface IUpdateConstraintsType<T>
    {
        ILogicalUpdateConstraints<T> Equal(object value);
        ILogicalUpdateConstraints<T> NotEqual(object value);
        ILogicalUpdateConstraints<T> Greater(object value);
        ILogicalUpdateConstraints<T> GreaterOrEqual(object value);
        ILogicalUpdateConstraints<T> Less(object value);
        ILogicalUpdateConstraints<T> LessOrEqual(object value);
        ILogicalUpdateConstraints<T> In(object value);
        ILogicalUpdateConstraints<T> In<TU>(ISubQuery<TU> subQuery);
        ILogicalUpdateConstraints<T> NotIn(object value);
        ILogicalUpdateConstraints<T> NotIn<TU>(ISubQuery<TU> subQuery);
        ILogicalUpdateConstraints<T> Like(string pattern);
        ILogicalUpdateConstraints<T> NotLike(string pattern);
        ILogicalUpdateConstraints<T> Between<TU>(TU begin, TU end);
        ILogicalUpdateConstraints<T> NotBetween<TU>(TU begin, TU end);
        ILogicalUpdateConstraints<T> IsNull();
        ILogicalUpdateConstraints<T> IsNotNull();
    }
}
