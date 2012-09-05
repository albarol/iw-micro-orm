using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IwMicroOrm.Core.Query.Restrictions
{
    public class ConstraintsCollection
    {
        private readonly IList<IConstraint> restrictions = new List<IConstraint>();

        public Parameter[] Parameters
        {
            get
            {
                return this.restrictions.SelectMany(r => r.Parameters).ToArray();
            }
        }

        public string Sql
        {
            get
            {
                if (this.restrictions.Count == 0)
                {
                    return string.Empty;
                }

                var builder = new StringBuilder(string.Format(" where {0}", this.restrictions[0].Condition));
                for (int i = 1; i < this.restrictions.Count; i++)
                {
                    builder.AppendFormat(" {0}", this.restrictions[i].Condition);
                }

                return builder.ToString();
            }
        }
        
        public void Add(IConstraint constraint)
        {
            this.restrictions.Add(constraint);
        }

        public void Remove(IConstraint constraint)
        {
            this.restrictions.Remove(constraint);
        }
    }
}
