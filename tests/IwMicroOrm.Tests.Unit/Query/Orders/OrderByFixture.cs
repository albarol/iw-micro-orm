namespace IwMicroOrm.Tests.Unit.Query.Orders
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    [Category("Select.Order")]
    public class OrderByFixture
    {
        [Test]
        public void ShouldHaveOrderAscedingInStatement()
        {
            // Arrange:
            const string Expected = "order by Id asc";

            // Act:
            var statement = SqlBuilder.Select<OrmType>().Order.Ascending(o => o.Id);

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveOrderDescedingInStatement()
        {
            // Arrange:
            const string Expected = "order by Id desc";

            // Act:
            var statement = SqlBuilder.Select<OrmType>().Order.Descending(o => o.Id);

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveTwoOrderAscedingInStatement()
        {
            // Arrange:
            const string Expected = "order by Id asc, OrmName asc";
            
            // Act:
            var statement = SqlBuilder.Select<OrmType>()
                                      .Order.Ascending(o => o.Id)
                                      .Order.Ascending(o => o.OrmName);

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveTwoOrderDescedingInStatement()
        {
            // Arrange:
            const string Expected = "order by Id desc, OrmName desc";

            // Act:
            var statement = SqlBuilder.Select<OrmType>()
                                      .Order.Descending(o => o.Id)
                                      .Order.Descending(o => o.OrmName);

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldHaveOneOrderDescedingAndOneOrderAscedingInStatement()
        {
            // Arrange:
            const string Expected = "order by Id desc, OrmName asc";

            // Act:
            var statement = SqlBuilder.Select<OrmType>()
                                      .Order.Descending(o => o.Id)
                                      .Order.Ascending(o => o.OrmName);

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

    }
}
