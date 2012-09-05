namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery;
    using IwMicroOrm.Tests.Unit.Helpers;
    using NUnit.Framework;
    using SharpTestsEx;
    
    [TestFixture]
    public class LogicalOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsAnd()
        {
            // Arrange:
            const string Expected = "Id = @IdEq and OrmName = @OrmNameEq";

            // Act:
            var statement = this.select.Where(o => o.Id).Equal(1).And.Where(o => o.OrmName).Equal("SQL-92");

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsOr()
        {
            // Arrange:
            const string Expected = "Id = @IdEq or OrmName = @OrmNameEq";

            // Act:
            this.select.Where(o => o.Id).Equal(1).Or.Where(o => o.OrmName).Equal("SQL-92");

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
