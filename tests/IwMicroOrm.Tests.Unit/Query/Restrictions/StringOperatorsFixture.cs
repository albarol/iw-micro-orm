namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class StringOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsLike()
        {
            // Arrange:
            const string Expected = "Id like @IdLike";
            
            // Act:
            this.select.Where(o => o.Id).Like("%1%");

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsNotLike()
        {
            // Arrange:
            const string Expected = "Id not like @IdNotLike";

            // Act:
            this.select.Where(o => o.Id).NotLike("%1%");

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
