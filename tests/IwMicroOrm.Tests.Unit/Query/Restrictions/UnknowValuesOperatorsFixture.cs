using IwMicroOrm.Core.Query.SelectQuery;

namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class UnknowValuesOperatorsFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }
        
        [Test]
        public void IsNull_ShouldHaveConditionWhenRestrictionIsNull()
        {
            // Arrange:
            const string Expected = "Id is null";

            // Act:
            this.select.Where(o => o.Id).IsNull();
            
            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void IsNotNull_ShouldHaveConditionWhenRestrictionIsNotNull()
        {
            // Arrange:
            const string Expected = "Id is not null";

            // Act:
            this.select.Where(o => o.Id).IsNotNull();

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        public void Custom_ShouldCreateCustomRestriction()
        {
            // Arrange:
            const string Expected = "Id is not null";

            // Act:
            this.select.Where("Id is not null");

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
    }
}
