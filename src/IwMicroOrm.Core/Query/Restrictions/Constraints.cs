using System;
using IwMicroOrm.Core.Query.Restrictions.Subqueries;

namespace IwMicroOrm.Core.Query.Restrictions
{
    public class Constraints
    {
        public static IConstraint Or()
        {
            return new Constraint("or", new Parameter[0]);
        }

        public static IConstraint And()
        {
            return new Constraint("and", new Parameter[0]);
        }
        
        public static IConstraint Equal(string column, object value)
        {
            return new Constraint(String.Format("{0} = @{0}Eq", column), new[] {new Parameter(String.Format("@{0}Eq", column)){Value = value}});
        }

        public static IConstraint NotEqual(string column, object value)
        {
            return new Constraint(String.Format("{0} <> @{0}Ne", column), new[] { new Parameter(String.Format("@{0}Ne", column)) { Value = value } });
        }

        public static IConstraint Greater(string column, object value)
        {
            return new Constraint(String.Format("{0} > @{0}Gt", column), new[] { new Parameter(String.Format("@{0}Gt", column)) { Value = value } });
        }

        public static IConstraint GreaterOrEqual(string column, object value)
        {
            return new Constraint(String.Format("{0} >= @{0}Ge", column), new[] { new Parameter(String.Format("@{0}Ge", column)) { Value = value } });
        }

        public static IConstraint Less(string column, object value)
        {
            return new Constraint(String.Format("{0} < @{0}Lt", column), new[] { new Parameter(String.Format("@{0}Lt", column)) { Value = value } });
        }

        public static IConstraint LessOrEqual(string column, object value)
        {
            return new Constraint(String.Format("{0} <= @{0}Le", column), new[] { new Parameter(String.Format("@{0}Le", column)) { Value = value } });
        }

        public static IConstraint In(string column, object value)
        {
            return new Constraint(String.Format("{0} in (@{0}In)", column), new[] { new Parameter(String.Format("@{0}In", column)) { Value = value } });
        }

        public static IConstraint In<TU>(string column, ISubQuery<TU> subQuery)
        {
            return new Constraint(String.Format("{0} in ({1})", column, subQuery.Sql), subQuery.Parameters);
        }

        public static IConstraint NotIn(string column, object value)
        {
            return new Constraint(String.Format("{0} not in (@{0}NotIn)", column), new[] { new Parameter(String.Format("@{0}NotIn", column)) { Value = value } });
        }

        public static IConstraint NotIn<TU>(string column, ISubQuery<TU> subQuery)
        {
            return new Constraint(String.Format("{0} not in ({1})", column, subQuery.Sql), subQuery.Parameters);
        }

        public static IConstraint Like(string column, string pattern)
        {
            return new Constraint(String.Format("{0} like @{0}Like", column), new[] { new Parameter(String.Format("@{0}Like", column)) { Value = pattern } });
        }

        public static IConstraint NotLike(string column, string pattern)
        {
            return new Constraint(String.Format("{0} not like @{0}NotLike", column), new[] { new Parameter(String.Format("@{0}NotLike", column)) { Value = pattern } });
        }


        public static IConstraint Between<TU>(string column, TU begin, TU end)
        {
            return new Constraint(String.Format("{0} between @{0}BtBegin and @{0}BtEnd", column), new[]
            {
                new Parameter(String.Format("@{0}BtBegin", column)){Value = begin},
                new Parameter(String.Format("@{0}BtEnd", column)){Value = end}
            });
        }

        public static IConstraint NotBetween<TU>(string column, TU begin, TU end)
        {
            return new Constraint(String.Format("{0} not between @{0}NbBegin and @{0}NbEnd", column), new[]
            {
                new Parameter(String.Format("@{0}NbBegin", column)){Value = begin},
                new Parameter(String.Format("@{0}NbEnd", column)){Value = end}
            });
        }

        public static IConstraint IsNull(string column)
        {
            return new Constraint(String.Format("{0} is null", column), new Parameter[0]);
        }

        public static IConstraint IsNotNull(string column)
        {
            return new Constraint(String.Format("{0} is not null", column), new Parameter[0]);
        }

        public static IConstraint Custom(string condition)
        {
            return new Constraint(condition, new Parameter[0]);
        }
    }
}
