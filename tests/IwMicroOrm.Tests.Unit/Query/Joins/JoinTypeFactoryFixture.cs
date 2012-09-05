namespace IwMicroOrm.Tests.Unit.Query.Joins
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery.Joins;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Select.Join")]
    public class JoinTypeFactoryFixture
    {
        [Test]
        public void ShouldBeAConditionForInnerJoin()
        {
            const string expected = "inner join";
            var statement = SqlBuilder.Select<OrmType>().Join.Inner<InnerOrmType>();
            statement.Sql.Should().Contain(expected);
        }
    }
}
