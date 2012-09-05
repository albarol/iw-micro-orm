using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IwMicroOrm.Core.Query.SelectQuery.Groups
{
    internal class GroupByCollection
    {
        private readonly IList<string> groups = new List<string>();

        public void Add(string group)
        {
            this.groups.Add(group);
        }

        public void Remove(string order)
        {
            this.groups.Remove(order);
        }

        public string Sql
        {
            get
            {
                if (this.groups.Count == 0) return string.Empty;
                var builder = new StringBuilder(" group by");
                foreach (string group in this.groups)
                    builder.AppendFormat(" {0},", group);
                builder.Remove(builder.Length - 1, 1);
                return builder.ToString();
            }
        }
    }
}
