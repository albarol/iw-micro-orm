namespace IwMicroOrm.Core.Query.DeleteQuery
{
    using System;
    using System.Linq.Expressions;
    using IwMicroOrm.Core.Query.DeleteQuery.Restrictions;
    using IwMicroOrm.Core.Query.Restrictions;
    using IwMicroOrm.Core.Shared;

    internal class Delete<T> : ILogicalDeleteConstraints<T>
    {
        private readonly Type entityType;
        private StatementBuilder builder;
        private readonly ConstraintsCollection bunchOfContraints;
        
        internal Delete()
        {
            this.entityType = typeof(T);
            this.bunchOfContraints = new ConstraintsCollection();
        }
        
        public string Sql
        {
            get
            {
                builder = new DeleteStatementBuilder(entityType, bunchOfContraints);
                return builder.Sql;
            }
        }

        public Parameter[] Parameters
        {
            get { return bunchOfContraints.Parameters; }
        }

        public IDeleteQuery<T> Where(string condition)
        {
            this.bunchOfContraints.Add(new Constraint(condition, new Parameter[0]));
            return this;
        }

        public IDeleteConstraintsType<T> Where(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new DeleteConstraints<T>(column.Name, this, this.bunchOfContraints);
        }

        public IDeleteQuery<T> Or
        {
            get
            {
                this.bunchOfContraints.Add(Constraints.Or());
                return this;
            }
        }

        public IDeleteQuery<T> And
        {
            get
            {
                this.bunchOfContraints.Add(Constraints.And());
                return this;
            }
        }
    }
}
