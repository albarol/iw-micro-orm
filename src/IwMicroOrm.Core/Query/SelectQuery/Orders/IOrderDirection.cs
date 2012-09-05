namespace IwMicroOrm.Core.Query.SelectQuery.Orders
{
    using System;
    using System.Linq.Expressions;

    public interface IOrderDirection<T> : ISqlStatement
    {
        ISelectQuery<T> Descending(Expression<Func<T, object>> parameter);
        ISelectQuery<T> Ascending(Expression<Func<T, object>> parameter);
    }
}
