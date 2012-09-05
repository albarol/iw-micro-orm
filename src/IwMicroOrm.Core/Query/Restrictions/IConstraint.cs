namespace IwMicroOrm.Core.Query.Restrictions
{
    public interface IConstraint
    {
        string Condition { get; }
        Parameter[] Parameters { get; }
    }
}
