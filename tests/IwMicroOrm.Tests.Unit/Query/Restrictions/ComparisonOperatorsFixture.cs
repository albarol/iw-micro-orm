namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using Core.Query;
    using Helpers;

    using IwMicroOrm.Core.Query.SelectQuery;

    using NUnit.Framework;
    using SharpTestsEx;
    
    [TestFixture]
    public class ComparisonOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsEqual()
        {
            // Assert:
            const string Expected = "Id = @IdEq";
            
            // Act:
            this.select.Where(o => o.Id).Equal(1);
            
            // Arrange:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsNotEqual()
        {
            // Arrange:
            const string Expected = "Id <> @IdNe";

            // Act:
            this.select.Where(o => o.Id).NotEqual(1);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsGreater()
        {
            // Arrange:
            const string Expected = "Id > @IdGt";

            // Act:
            this.select.Where(o => o.Id).Greater(1);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsGreaterOrEqual()
        {
            // Arrange:
            const string Expected = "Id >= @IdGe";

            // Act:
            this.select.Where(o => o.Id).GreaterOrEqual(1);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsLess()
        {
            // Arrange:
            const string Expected = "Id < @IdLt";

            // Act:
            this.select.Where(o => o.Id).Less(1);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveConditionWhenRestrictionIsLessOrEqual()
        {
            // Arrange:
            const string Expected = "Id <= @IdLe";

            // Act:
            this.select.Where(o => o.Id).LessOrEqual(1);

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
