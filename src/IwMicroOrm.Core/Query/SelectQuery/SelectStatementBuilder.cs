using IwMicroOrm.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IwMicroOrm.Core.Query.SelectQuery
{
    internal class SelectStatementBuilder<T> : StatementBuilder
    {
        private readonly SelectFragment<T> fragment;

        private StringBuilder builder;


        public SelectStatementBuilder(SelectFragment<T> fragment)
        {
            this.fragment = fragment;
            this.Build();
        }

        protected override void Build()
        {
            builder = new StringBuilder();
            builder.Append(BuildBaseStatement());
            builder.Append(BuildComplements());
        }

        private string BuildBaseStatement()
        {
            var baseStatement = new StringBuilder("select ");
            
            if (this.fragment.Fields.Count > 0)
            {
                foreach(var field in this.fragment.Fields)
                {
                    baseStatement.AppendFormat("{0}, ", field.Sql);
                }
            }
            else
            {
                IEnumerable<PropertyInfo> properties = typeof(T).GetProperties().Where(p => p.CanWrite);

                foreach (PropertyInfo property in properties)
                {
                    if (PropertyInfoHelper.IsManyRelation(property.PropertyType))
                        continue;
                    baseStatement.AppendFormat("{0}, ", property.Name);
                }
            }

            baseStatement.Remove(baseStatement.Length - 2, 2);
            baseStatement.AppendFormat(" from {0}", typeof(T).Name);
            return baseStatement.ToString();
        }


        private string BuildComplements()
        {
            var complements = new StringBuilder();
            complements.Append(fragment.Joins.Sql);
            complements.Append(fragment.Contraints.Sql);
            complements.Append(fragment.Groups.Sql);
            complements.Append(fragment.Orders.Sql);
            return complements.ToString();
        }

        public override string Sql
        {
            get { return builder.ToString(); }
        }

        public override Parameter[] Parameters
        {
            get { return fragment.Contraints.Parameters; }
        }
    }
}
