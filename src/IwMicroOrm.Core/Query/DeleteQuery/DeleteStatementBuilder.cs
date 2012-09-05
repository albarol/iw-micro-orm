using System;
using System.Text;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.DeleteQuery
{
    internal sealed class DeleteStatementBuilder : StatementBuilder
    {
        private readonly StringBuilder builder = new StringBuilder();
        private readonly Type entity;
        private readonly ConstraintsCollection bunchOfConstraints;

        public DeleteStatementBuilder(Type entityType, ConstraintsCollection bunchOfContraints)
        {
            this.entity = entityType;
            this.bunchOfConstraints = bunchOfContraints;
            this.Build();
        }

        protected override void Build()
        {
            if (entity == null) throw new ArgumentNullException("entityType is null.");
            
            builder.AppendFormat("delete from {0}", this.entity.Name);
            if (this.bunchOfConstraints != null)
                builder.Append(this.bunchOfConstraints.Sql);
        }

        public override string Sql
        {
            get { return builder.ToString(); }
        }

        public override Parameter[] Parameters
        {
            get { return new Parameter[0]; }
        }
    }
}
