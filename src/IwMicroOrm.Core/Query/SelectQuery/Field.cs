using System;
using System.Linq.Expressions;
using IwMicroOrm.Core.Query.SelectQuery.Functions;
using IwMicroOrm.Core.Shared;

namespace IwMicroOrm.Core.Query.SelectQuery
{
    public sealed class Field<T> : ISqlStatement
    {
        public string Sql { get; private set; }

        public static Field<T> Property(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T>{ Sql = column.Name };
        }

        public static Field<T> Distinct(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> {Sql = FunctionStatement.Distinct(column.Name)};
        }
        
        public static Field<T> Avg(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> { Sql = FunctionStatement.Avg(column.Name) };
        }

        public static Field<T> Count(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> { Sql = FunctionStatement.Count(column.Name) };
        }

        public static Field<T> Max(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> { Sql = FunctionStatement.Max(column.Name) };
        }

        public static Field<T> Min(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> { Sql = FunctionStatement.Min(column.Name) };
        }

        public static Field<T> Sum(Expression<Func<T, object>> parameter)
        {
            var column = PropertyInfoHelper.GetPropertyFromExpression(parameter);
            return new Field<T> { Sql = FunctionStatement.Sum(column.Name) };
        }
    }
}
