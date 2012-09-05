namespace IwMicroOrm.Core.Query.SelectQuery.Orders
{
    using System;
    using System.Linq.Expressions;

    using IwMicroOrm.Core.Shared;

    internal class OrderDirection<T> : IOrderDirection<T>
    {
        private readonly ISelectQuery<T> select;
        private string column;
        private readonly OrderCollection orders;

        public OrderDirection(ISelectQuery<T> select, OrderCollection orders)
        {
            this.select = select;
            this.orders = orders;
        }

        public string Sql
        {
            get { return this.column; }
        }

        public ISelectQuery<T> Descending(Expression<Func<T, object>> parameter)
        {
            var propertyInfo = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            this.column = string.Format("{0} desc", propertyInfo.Name);
            this.orders.Add(this);
            return this.select;
        }

        public ISelectQuery<T> Ascending(Expression<Func<T, object>> parameter)
        {
            var propertyInfo = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            this.column = string.Format("{0} asc", propertyInfo.Name);
            this.orders.Add(this);
            return this.select;
        }
    }
}
