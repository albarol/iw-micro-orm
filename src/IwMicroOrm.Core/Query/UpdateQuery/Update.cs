using System;
using System.Linq.Expressions;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Query.UpdateQuery.Restrictions;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.UpdateQuery
{
    internal class Update<T> : ILogicalUpdateConstraints<T> where T : class
    {
        private StatementBuilder builder;
        private readonly T entity;
        private ConstraintsCollection bunchOfContraints;

        internal Update(T entity)
        {
            this.entity = entity;
        }

        public string Sql
        {
            get
            {
                builder = new UpdateStatementBuilder(entity, this.bunchOfContraints);
                return builder.Sql;
            }
        }

        public Parameter[] Parameters
        {
            get
            {
                builder = new UpdateStatementBuilder(entity, this.bunchOfContraints);
                return builder.Parameters;
            }
        }

        public IUpdateQuery<T> Where(string condition)
        {
            if (this.bunchOfContraints == null)
            {
                this.bunchOfContraints = new ConstraintsCollection();
            }

            this.bunchOfContraints.Add(new Constraint(condition, new Parameter[0]));

            return this;
        }

        public IUpdateConstraintsType<T> Where(Expression<Func<T, object>> parameter)
        {
            if (this.bunchOfContraints == null)
            {
                this.bunchOfContraints = new ConstraintsCollection();
            }

            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new UpdateConstraints<T>(column.Name, this, this.bunchOfContraints);
        }

        public IUpdateQuery<T> Or
        {
            get
            {
                this.bunchOfContraints.Add(Constraints.Or());
                return this;
            }
        }

        public IUpdateQuery<T> And
        {
            get
            {
                this.bunchOfContraints.Add(Constraints.And());
                return this;
            }
        }
    }
}
