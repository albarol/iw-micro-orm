namespace IwMicroOrm.Core.Query.Restrictions.Subqueries
{
    public interface ISubQueryConstraintsType<out T>
    {
        T Equal(object value);
        T NotEqual(object value);
        T Greater(object value);
        T GreaterOrEqual(object value);
        T Less(object value);
        T LessOrEqual(object value);
        T In(object value);
        T NotIn(object value);
        T Like(string pattern);
        T NotLike(string pattern);
        T Between<TU>(TU begin, TU end);
        T NotBetween<TU>(TU begin, TU end);
        T IsNull();
        T IsNotNull();
    }
}
