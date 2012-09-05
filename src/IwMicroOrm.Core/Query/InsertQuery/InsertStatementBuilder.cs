using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IwMicroOrm.Core.Mapping;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.InsertQuery
{
    internal sealed class InsertStatementBuilder : StatementBuilder
    {
        private readonly StringBuilder builder = new StringBuilder();
        private readonly IList<Parameter> parameters = new List<Parameter>();
        private readonly object entity;

        public InsertStatementBuilder(object entity)
        {
            if (entity == null) throw new ArgumentNullException("entityType is null.");
            if (!IsEntity(entity)) throw new ArgumentException(string.Format("{0} not is a entity!", entity.GetType().Name));
            this.entity = entity;
            this.Build();
        }

        public override string Sql
        {
            get { return builder.ToString(); }
        }

        public override Parameter[] Parameters
        {
            get { return parameters.ToArray(); }
        }

        protected override void Build()
        {
            var columns = new StringBuilder();
            var param = new StringBuilder();

            foreach (PropertyInfo property in PropertyInfoHelper.GetEntityProperties(this.entity))
            {
                columns.AppendFormat("{0},", property.Name);
                param.AppendFormat("@{0},", property.Name);
                parameters.Add(new Parameter
                {
                    Column = string.Format("@{0}", property.Name),
                    Value = property.GetValue(this.entity, null)
                });
            }
            columns.Remove(columns.Length - 1, 1);
            param.Remove(param.Length - 1, 1); 
            
            builder.AppendFormat("insert into {0}({1}) values({2})", entity.GetType().Name, columns, param);
        }

        private bool IsEntity(object entity)
        {
            return entity.GetType().GetInterface(typeof(IEntity<>).Name) != null;
        }
    }
}
