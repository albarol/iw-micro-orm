using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.DeleteQuery.Restrictions
{
    using IwMicroOrm.Core.Query.Restrictions;

    public class DeleteConstraints<T> : IDeleteConstraintsType<T>
    {
        private readonly string column;
        protected readonly ILogicalDeleteConstraints<T> Query;
        protected readonly ConstraintsCollection BunchOfConstraints;

        internal DeleteConstraints(string column, ILogicalDeleteConstraints<T> query, ConstraintsCollection bunchOfContraints)
        {
            this.column = column;
            this.Query = query;
            this.BunchOfConstraints = bunchOfContraints;
        }
        
        public ILogicalDeleteConstraints<T> Equal(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Equal(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> NotEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotEqual(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> Greater(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Greater(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> GreaterOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.GreaterOrEqual(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> Less(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Less(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> LessOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.LessOrEqual(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> In(object value)
        {
            this.BunchOfConstraints.Add(Constraints.In(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> In<TU>(ISubQuery<TU> subQuery)
        {
            this.BunchOfConstraints.Add(Constraints.In(this.column, subQuery));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> NotIn(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotIn(this.column, value));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> NotIn<TU>(ISubQuery<TU> subQuery)
        {
            this.BunchOfConstraints.Add(Constraints.NotIn(this.column, subQuery));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> Like(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.Like(this.column, pattern));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> NotLike(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.NotLike(this.column, pattern));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> Between<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.Between(this.column, begin, end));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> NotBetween<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.NotBetween(this.column, begin, end));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> IsNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNull(this.column));
            return this.Query;
        }

        public ILogicalDeleteConstraints<T> IsNotNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNotNull(this.column));
            return this.Query;
        }
    }
}
