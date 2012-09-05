using System.Collections.Generic;
using System.Text;

namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    internal class JoinCollection
    {
        private readonly IList<JoinStatement> joins = new List<JoinStatement>();

        public void Add(JoinStatement statement)
        {
            this.joins.Add(statement);
        }

        public void Remove(JoinStatement order)
        {
            this.joins.Remove(order);
        }

        public string Sql
        {
            get
            {
                if (this.joins.Count == 0) return string.Empty;
                var builder = new StringBuilder();
                foreach(var join in joins)
                    builder.AppendFormat("{0}", join.Sql);
                return builder.ToString();
            }
        }
    }
}
