using System.Collections.Generic;
using IwMicroOrm.Core.Query.Restrictions;
using IwMicroOrm.Core.Query.SelectQuery.Functions;
using IwMicroOrm.Core.Query.SelectQuery.Groups;
using IwMicroOrm.Core.Query.SelectQuery.Joins;
using IwMicroOrm.Core.Query.SelectQuery.Orders;

namespace IwMicroOrm.Core.Query.SelectQuery
{
    internal class SelectFragment<T>
    {
        public OrderCollection Orders { get; private set; }
        public ConstraintsCollection Contraints { get; private set; }
        public GroupByCollection Groups { get; private set; }
        public JoinCollection Joins { get; private set; }
        public IList<Field<T>> Fields { get; internal set; }

        public SelectFragment()
        {
            this.Orders = new OrderCollection();
            this.Contraints = new ConstraintsCollection();
            this.Groups = new GroupByCollection();
            this.Joins = new JoinCollection();
            this.Fields = new List<Field<T>>();
        }
    }
}
