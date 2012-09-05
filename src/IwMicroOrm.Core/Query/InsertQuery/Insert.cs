using System.Collections.Generic;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.InsertQuery
{
    public class Insert : IInsertQuery
    {
        private readonly StatementBuilder builder;

        public Insert(object entity)
        {
            builder = new InsertStatementBuilder(entity);
        }

        public string Sql
        {
            get { return builder.Sql; }
        }

        public Parameter[] Parameters
        {
            get { return builder.Parameters; }
        }
    }
}
