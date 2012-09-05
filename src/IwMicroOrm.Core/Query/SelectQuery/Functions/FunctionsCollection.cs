using System.Collections.Generic;
using System.Text;

namespace IwMicroOrm.Core.Query.SelectQuery.Functions
{
    internal class FunctionsCollection
    {
        private readonly IDictionary<string, FunctionStatement> functions = new Dictionary<string, FunctionStatement>();

        public void Add(FunctionStatement function)
        {
            this.functions.Add(function.Column, function);
        }

        public void Remove(FunctionStatement function)
        {
            this.functions.Add(function.Column, function);
        }

        public FunctionStatement this[string column]
        {
            get { return functions[column]; }
        } 

        public bool ContainsKey(string column)
        {
            return functions.ContainsKey(column);
        }
    }
}
