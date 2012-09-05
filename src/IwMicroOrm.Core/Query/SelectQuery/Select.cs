using System.Linq;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Query.SelectQuery.Restrictions;

namespace IwMicroOrm.Core.Query.SelectQuery
{
    using System;
    using System.Linq.Expressions;

    using IwMicroOrm.Core.Query.SelectQuery.Joins;
    using IwMicroOrm.Core.Query.SelectQuery.Orders;
    using IwMicroOrm.Core.Shared;

    internal class Select<T> : ILogicalSelectConstraints<T>
    {
        private StatementBuilder builder;
        private readonly SelectFragment<T> fragment;
        
        internal Select(params Field<T>[] fields)
        {
            this.fragment = new SelectFragment<T>();

            if (fields.Length > 0)
            {
                this.fragment.Fields = fields.ToList();
            }
        }

        public string Sql
        {
            get
            {
                builder = new SelectStatementBuilder<T>(fragment);
                return builder.Sql;
            }
        }

        public Parameter[] Parameters
        {
            get
            {
                return this.fragment.Contraints.Parameters;
            }
        }

        public IJoinType<T> Join
        {
            get
            {
                return new JoinTypeFactory<T>(this, this.fragment.Joins);
            }
        }

        public IOrderDirection<T> Order
        {
            get
            {
                return new OrderDirection<T>(this, this.fragment.Orders);
            }
        }

        public ISelectQuery<T> GroupBy(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            this.fragment.Groups.Add(column.Name);
            return this;
        }

        ISelectConstraintsType<T> ISelectQuery<T>.Where(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new SelectConstraints<T>(column.Name, this, this.fragment.Contraints);
        }

        ISelectQuery<T> ISelectQuery<T>.Where(string condition)
        {
            this.fragment.Contraints.Add(Constraints.Custom(condition));
            return this;
        }

        public ISelectQuery<T> Or
        {
            get
            {
                this.fragment.Contraints.Add(Constraints.Or());
                return this;
            }
        }

        public ISelectQuery<T> And
        {
            get
            {
                this.fragment.Contraints.Add(Constraints.And());
                return this;
            }
        }
    }
}