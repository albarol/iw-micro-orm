using System;
using System.Linq.Expressions;
using IwMicroOrm.Core.Query.DeleteQuery.Restrictions;

namespace IwMicroOrm.Core.Query.DeleteQuery
{
    public interface IDeleteQuery<T> : IParameterizableStatement
    {
        IDeleteConstraintsType<T> Where(Expression<Func<T, object>> parameter);
        IDeleteQuery<T> Where(string condition);
    }
}
