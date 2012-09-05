namespace IwMicroOrm.Core.Query.SelectQuery.Orders
{
    using System.Collections.Generic;
    using System.Text;

    public class OrderCollection
    {
        private readonly IList<ISqlStatement> orders = new List<ISqlStatement>();

        public void Add(ISqlStatement order)
        {
            this.orders.Add(order);
        }

        public void Remove(ISqlStatement order)
        {
            this.orders.Remove(order);
        }

        public string Sql
        {
            get
            {
                if (this.orders.Count == 0) return "";
                var builder = new StringBuilder(string.Format(" order by {0}", this.orders[0].Sql));
                for (int i = 1; i < this.orders.Count; i++)
                    builder.AppendFormat(", {0}", this.orders[i].Sql);
                return builder.ToString();
            }
        }
    }
}
