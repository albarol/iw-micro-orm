using System;

namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    internal class RightOuterJoin : JoinStatement
    {
        public RightOuterJoin(Type innerType, Type foreignType) : base(innerType, foreignType)
        {
        }
        
        public override string Sql
        {
            get
            {
                return (this.RelationType == RelationType.OneToOne)
                        ? string.Format(" right join {1} on {0}.{1}Id = {1}.Id", this.InnerType.Name, this.ForeignType.Name)
                        : string.Format(" right join {1} on {0}.Id = {1}.{0}Id", this.InnerType.Name, this.ForeignType.Name);
            }
        }
    }
}
