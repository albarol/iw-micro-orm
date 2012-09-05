namespace IwMicroOrm.Core.Query.Restrictions
{
    public class Constraint : IConstraint
    {
        public Constraint(string condition, Parameter[] parameters)
        {
            this.Condition = condition;
            this.Parameters = parameters;
        }

        public string Condition { get; private set; }
        public Parameter[] Parameters { get; private set; }
    }
}
