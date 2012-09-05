namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class BetweenOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsBetween()
        {
            // Arrange:
            const string Expected = "Id between @IdBtBegin and @IdBtEnd";

            // Act:
            this.select.Where(o => o.Id).Between(1, 3);
            
            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShoudHaveConditionWhenRestrictionIsNotBetween()
        {
            // Arrange:
            const string Expected = "Id not between @IdNbBegin and @IdNbEnd";

            // Act:
            this.select.Where(o => o.Id).NotBetween(1, 3);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
