using System;
using System.Linq.Expressions;
using IwMicroOrm.Core.Query.UpdateQuery.Restrictions;

namespace IwMicroOrm.Core.Query.UpdateQuery
{
    public interface IUpdateQuery<T> : IParameterizableStatement
    {
        IUpdateConstraintsType<T> Where(Expression<Func<T, object>> parameter);
        IUpdateQuery<T> Where(string condition);
    }
}
