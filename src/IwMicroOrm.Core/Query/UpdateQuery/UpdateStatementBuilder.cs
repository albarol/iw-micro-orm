using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.UpdateQuery
{
    internal class UpdateStatementBuilder : StatementBuilder
    {
        private StringBuilder builder;
        private List<Parameter> parameters;
        private readonly ConstraintsCollection bunchOfConstraints;
        private readonly object entity;

        public UpdateStatementBuilder(object entity, ConstraintsCollection bunchOfConstraints)
        {
            if (entity == null) throw new ArgumentNullException("entityType is null.");
            this.entity = entity;
            this.bunchOfConstraints = bunchOfConstraints;
            this.Build();
        }


        protected override void Build()
        {
            builder = new StringBuilder();
            parameters = new List<Parameter>();
            
            builder.AppendFormat("update {0}", entity.GetType().Name);
            builder.Append(" set ");
            foreach (PropertyInfo property in PropertyInfoHelper.GetEntityProperties(this.entity))
            {
                builder.AppendFormat("{0} = @{0}, ", property.Name);
                parameters.Add(new Parameter
                {
                    Column = string.Format("@{0}", property.Name),
                    Value = property.GetValue(this.entity, null)
                });
            }
            builder.Remove(builder.Length - 2, 2);

            if (this.bunchOfConstraints != null)
            {
                builder.Append(this.bunchOfConstraints.Sql);
                parameters.AddRange(this.bunchOfConstraints.Parameters);   
            }
        }

        public override string Sql
        {
            get { return builder.ToString(); }
        }

        public override Parameter[] Parameters
        {
            get { return this.parameters.ToArray(); }
        }
    }
}
