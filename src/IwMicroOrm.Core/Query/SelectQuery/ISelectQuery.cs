namespace IwMicroOrm.Core.Query.SelectQuery
{
    using System;
    using System.Linq.Expressions;
    using IwMicroOrm.Core.Query.SelectQuery.Restrictions;
    using IwMicroOrm.Core.Query.SelectQuery.Joins;
    using IwMicroOrm.Core.Query.SelectQuery.Orders;

    public interface ISelectQuery<T> : IParameterizableStatement
    {
        IJoinType<T> Join { get; }
        IOrderDirection<T> Order { get; }
        ISelectQuery<T> GroupBy(Expression<Func<T, object>> parameter);
        ISelectConstraintsType<T> Where(Expression<Func<T, object>> parameter);
        ISelectQuery<T> Where(string condition);
    }
}
