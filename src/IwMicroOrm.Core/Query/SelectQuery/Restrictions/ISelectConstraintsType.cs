using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.SelectQuery.Restrictions
{
    public interface ISelectConstraintsType<T>
    {
        ILogicalSelectConstraints<T> Equal(object value);
        ILogicalSelectConstraints<T> NotEqual(object value);
        ILogicalSelectConstraints<T> Greater(object value);
        ILogicalSelectConstraints<T> GreaterOrEqual(object value);
        ILogicalSelectConstraints<T> Less(object value);
        ILogicalSelectConstraints<T> LessOrEqual(object value);
        ILogicalSelectConstraints<T> In(object value);
        ILogicalSelectConstraints<T> In<TU>(ISubQuery<TU> subQuery);
        ILogicalSelectConstraints<T> NotIn(object value);
        ILogicalSelectConstraints<T> NotIn<TU>(ISubQuery<TU> subQuery);
        ILogicalSelectConstraints<T> Like(string pattern);
        ILogicalSelectConstraints<T> NotLike(string pattern);
        ILogicalSelectConstraints<T> Between<TU>(TU begin, TU end);
        ILogicalSelectConstraints<T> NotBetween<TU>(TU begin, TU end);
        ILogicalSelectConstraints<T> IsNull();
        ILogicalSelectConstraints<T> IsNotNull();
    }
}
