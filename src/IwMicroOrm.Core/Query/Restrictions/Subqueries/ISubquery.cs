namespace IwMicroOrm.Core.Query.Restrictions.Subqueries
{
    using System;
    using System.Linq.Expressions;
    
    public interface ISubQuery<T> : IParameterizableStatement
    {
        ISubQuery<T> Where(string condition);
        ISubQueryConstraintsType<ISubQuery<T>> Where(Expression<Func<T, object>> parameter);
    }
}
