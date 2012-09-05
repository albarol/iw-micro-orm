using IwMicroOrm.Core.Query;

namespace IwMicroOrm.Core.Shared
{
    public abstract class StatementBuilder : IParameterizableStatement
    {
        protected abstract void Build();
        
        public abstract string Sql { get; }
        public abstract Parameter[] Parameters { get; }
    }
}
