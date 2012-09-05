using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.SelectQuery.Restrictions
{
    internal class SelectConstraints<T> : ISelectConstraintsType<T>
    {
        private readonly string column;
        protected readonly ILogicalSelectConstraints<T> Query;
        protected readonly ConstraintsCollection BunchOfConstraints;

        internal SelectConstraints(string column, ILogicalSelectConstraints<T> query, ConstraintsCollection bunchOfContraints)
        {
            this.column = column;
            this.Query = query;
            this.BunchOfConstraints = bunchOfContraints;
        }
        
        public ILogicalSelectConstraints<T> Equal(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Equal(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> NotEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotEqual(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> Greater(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Greater(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> GreaterOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.GreaterOrEqual(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> Less(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Less(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> LessOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.LessOrEqual(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> In(object value)
        {
            this.BunchOfConstraints.Add(Constraints.In(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> In<TU>(ISubQuery<TU> subQuery)
        {
            this.BunchOfConstraints.Add(Constraints.In(this.column, subQuery));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> NotIn(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotIn(this.column, value));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> NotIn<TU>(ISubQuery<TU> subQuery)
        {
            this.BunchOfConstraints.Add(Constraints.NotIn(this.column, subQuery));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> Like(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.Like(this.column, pattern));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> NotLike(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.NotLike(this.column, pattern));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> Between<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.Between(this.column, begin, end));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> NotBetween<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.NotBetween(this.column, begin, end));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> IsNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNull(this.column));
            return this.Query;
        }

        public ILogicalSelectConstraints<T> IsNotNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNotNull(this.column));
            return this.Query;
        }
    }
}
