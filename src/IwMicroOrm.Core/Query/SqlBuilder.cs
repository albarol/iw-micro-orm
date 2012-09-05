using System.Linq.Expressions;
using IwMicroOrm.Core.Query.InsertQuery;
using IwMicroOrm.Core.Query.UpdateQuery;

namespace IwMicroOrm.Core.Query
{
    using System;

    using IwMicroOrm.Core.Query.DeleteQuery;
    using IwMicroOrm.Core.Query.SelectQuery;

    public static class SqlBuilder
    {
        public static ISelectQuery<T> Select<T>(params Field<T>[] fields)
        {
            return new Select<T>(fields);
        }

        public static IDeleteQuery<T> Delete<T>()
        {
            return new Delete<T>();
        }

        public static IInsertQuery Insert(object entity)
        {
            return new Insert(entity);
        }

        public static IUpdateQuery<T> Update<T>(T entity) where T : class
        {
            return new Update<T>(entity);
        }
    }
}
