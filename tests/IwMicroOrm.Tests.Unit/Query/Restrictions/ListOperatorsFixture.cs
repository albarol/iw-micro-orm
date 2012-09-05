namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class ListOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsIn()
        {
            // Arrange:
            const string Expected = "Id in (@IdIn)";

            // Act:
            this.select.Where(o => o.Id).In(new[] { 1, 2, 4, 5 });

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsNotIn()
        {
            // Arrange:
            const string Expected = "Id not in (@IdNotIn)";

            // Act:
            this.select.Where(o => o.Id).NotIn(new[] { 1, 2, 4, 5 });

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
