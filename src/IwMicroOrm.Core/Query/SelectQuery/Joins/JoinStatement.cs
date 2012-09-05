using System;

namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    internal abstract class JoinStatement : ISqlStatement
    {
        protected Type InnerType { get; private set; }
        protected Type ForeignType { get; private set; }

        protected JoinStatement(Type innerType, Type foreignType)
        {
            this.InnerType = innerType;
            this.ForeignType = foreignType;
            this.RelationType = Relation.GetRelationBetweenTypes(this.InnerType, this.ForeignType);
        }

        protected RelationType RelationType { get; private set; }
        public abstract string Sql { get; }
    }
}
