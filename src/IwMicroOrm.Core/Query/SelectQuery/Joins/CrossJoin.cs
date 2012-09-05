using System;

namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    internal class CrossJoin : JoinStatement
    {
        public CrossJoin(Type innerType, Type foreignType) : base(innerType, foreignType)
        {
        }

        public override string Sql
        {
            get { return string.Format(" cross join {0}", this.ForeignType.Name); }
        }
    }
}
