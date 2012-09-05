namespace IwMicroOrm.Core.Query
{
    public interface IParameterizableStatement : ISqlStatement
    {
        Parameter[] Parameters { get; }
    }
}
