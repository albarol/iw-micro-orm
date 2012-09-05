namespace IwMicroOrm.Core.Query.Restrictions.Subqueries
{
    using System;
    using System.Linq.Expressions;

    using IwMicroOrm.Core.Shared;

    public class SubQuery
    {
        public static SubQuery<T> CreateFrom<T>(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new SubQuery<T>(column.Name);
        }
    }

    public class SubQuery<T> : ISubQuery<T>
    {
        private readonly string column;
        private readonly ConstraintsCollection bunchOfContraints;

        internal SubQuery(string column)
        {
            this.column = column;
            this.bunchOfContraints = new ConstraintsCollection();
        }

        public string Sql
        {
            get
            {
                return string.Format("select {0} from {1}", this.column, typeof(T).Name);
            }
        }

        public Parameter[] Parameters
        {
            get
            {
                return this.bunchOfContraints.Parameters;
            }
        }

        public ISubQuery<T> Where(string condition)
        {
            this.bunchOfContraints.Add(new Constraint(condition, new Parameter[0]));
            return this;
        }

        public ISubQueryConstraintsType<ISubQuery<T>> Where(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new SubQueryConstraints<ISubQuery<T>>(column.Name, this, this.bunchOfContraints);
        }
    }
}