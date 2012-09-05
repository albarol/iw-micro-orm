namespace IwMicroOrm.Core.Query.SelectQuery.Functions
{
    internal class FunctionStatement
    {
        private static string Sql(string column, string function)
        {
            return string.Format("{0}({1})", function, column);
        }

        internal static string Avg(string column)
        {
            return Sql(column, FunctionType.Avg);
        }

        internal static string Min(string column)
        {
            return Sql(column, FunctionType.Min);
        }

        internal static string Max(string column)
        {
            return Sql(column, FunctionType.Max);
        }

        internal static string Distinct(string column)
        {
            return Sql(column, FunctionType.Distinct);
        }

        internal static string Sum(string column)
        {
            return Sql(column, FunctionType.Sum);
        }

        internal static string Count(string column)
        {
            return Sql(column, FunctionType.Count);
        }
    }
}
