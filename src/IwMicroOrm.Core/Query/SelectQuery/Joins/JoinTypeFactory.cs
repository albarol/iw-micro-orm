namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    using System;

    internal class JoinTypeFactory<T> : IJoinType<T>
    {
        private readonly JoinCollection collection;
        private readonly ISelectQuery<T> select; 

        internal JoinTypeFactory(ISelectQuery<T> select, JoinCollection collection)
        {
            this.select = select;
            this.collection = collection;
        }

        public ISelectQuery<T> Inner<TU>()
        {
            this.collection.Add(new InnerJoin(typeof(T), typeof(TU)));
            return this.select;
        }

        public ISelectQuery<T> Left<TU>()
        {
            this.collection.Add(new LeftJoin(typeof(T), typeof(TU)));
            return this.select;
        }

        public ISelectQuery<T> LeftOuter<TU>()
        {
            this.collection.Add(new LeftOuterJoin(typeof(T), typeof(TU)));
            return this.select;
        }

        public ISelectQuery<T> Right<TU>()
        {
            this.collection.Add(new RightJoin(typeof(T), typeof(TU)));
            return this.select;
        }

        public ISelectQuery<T> RightOuter<TU>()
        {
            this.collection.Add(new RightOuterJoin(typeof(T), typeof(TU)));
            return this.select;
        }

        public ISelectQuery<T> Cross<TU>()
        {
            this.collection.Add(new RightOuterJoin(typeof(T), typeof(TU)));
            return this.select;
        }
    }
}
