namespace IwMicroOrm.Tests.Unit.Query.Joins
{
    using System;

    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery.Joins;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Select.Join")]
    public class InnerJoinFixture
    {
        [Test]
        public void ShouldFindManyToOneRelation()
        {
            // Arrange:
            const string Expected = "inner join OrmType on InnerOrmType.OrmTypeId = OrmType.Id";

            // Act:
            var statement = SqlBuilder.Select<InnerOrmType>().Join.Inner<OrmType>();

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldFindOneToManyRelation()
        {
            // Arrange:
            const string Expected = "inner join InnerOrmType on OrmType.Id = InnerOrmType.OrmTypeId";

            // Act:
            var statement = SqlBuilder.Select<OrmType>().Join.Inner<InnerOrmType>();

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldFindOneToOneRelation()
        {
            // Arrange:
            const string Expected = "inner join OrmType on AnotherOrmType.OrmTypeId = OrmType.Id";

            // Act:
            var statement = SqlBuilder.Select<AnotherOrmType>().Join.Inner<OrmType>();

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

        [Test]
        public void ShouldFindOneToManyRelationWhenChildrenIsArray()
        {
            // Arrange:
            const string Expected = "inner join InnerOrmType on OrmTypeWithArray.Id = InnerOrmType.OrmTypeWithArrayId";

            // Act:
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Join.Inner<InnerOrmType>();

            // Assert:
            statement.Sql.Should().Contain(Expected);
        }

       
        [Test]
        [ExpectedException(typeof(InvalidJoinException))]
        public void ThrowsExceptionWhenTypesNotContainsJoin()
        {
            SqlBuilder.Select<OrmTypeWithArray>().Join.Inner<OrmTypeWithoutJoin>();
        }
    }
}