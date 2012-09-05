using IwMicroOrm.Core.Query.DeleteQuery.Restrictions;

namespace IwMicroOrm.Core.Query.Restrictions.Subqueries
{
    public class SubQueryConstraints<T> : ISubQueryConstraintsType<T>
    {
        private readonly string column;
        protected readonly T Query;
        protected readonly ConstraintsCollection BunchOfConstraints;

        internal SubQueryConstraints(string column, T query, ConstraintsCollection bunchOfContraints)
        {
            this.column = column;
            this.Query = query;
            this.BunchOfConstraints = bunchOfContraints;
        }

        public T Equal(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Equal(this.column, value));
            return this.Query;
        }

        public T NotEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotEqual(this.column, value));
            return this.Query;
        }

        public T Greater(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Greater(this.column, value));
            return this.Query;
        }

        public T GreaterOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.GreaterOrEqual(this.column, value));
            return this.Query;
        }

        public T Less(object value)
        {
            this.BunchOfConstraints.Add(Constraints.Less(this.column, value));
            return this.Query;
        }

        public T LessOrEqual(object value)
        {
            this.BunchOfConstraints.Add(Constraints.LessOrEqual(this.column, value));
            return this.Query;
        }

        public T In(object value)
        {
            this.BunchOfConstraints.Add(Constraints.In(this.column, value));
            return this.Query;
        }

        public T NotIn(object value)
        {
            this.BunchOfConstraints.Add(Constraints.NotIn(this.column, value));
            return this.Query;
        }

        public T Like(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.Like(this.column, pattern));
            return this.Query;
        }

        public T NotLike(string pattern)
        {
            this.BunchOfConstraints.Add(Constraints.NotLike(this.column, pattern));
            return this.Query;
        }

        public T Between<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.Between(this.column, begin, end));
            return this.Query;
        }

        public T NotBetween<TU>(TU begin, TU end)
        {
            this.BunchOfConstraints.Add(Constraints.NotBetween(this.column, begin, end));
            return this.Query;
        }

        public T IsNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNull(this.column));
            return this.Query;
        }

        public T IsNotNull()
        {
            this.BunchOfConstraints.Add(Constraints.IsNotNull(this.column));
            return this.Query;
        }
    }
}
