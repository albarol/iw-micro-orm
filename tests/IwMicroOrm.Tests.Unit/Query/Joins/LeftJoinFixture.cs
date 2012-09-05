using System;
using IwMicroOrm.Core.Query;
using IwMicroOrm.Tests.Unit.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace IwMicroOrm.Tests.Unit.Query.Joins
{
    using IwMicroOrm.Core.Query.SelectQuery.Joins;

    [TestFixture, Category("Select.Join")]
    public class LeftJoinFixture
    {
        [Test]
        public void ShouldFindManyToOneRelation()
        {
            var statement = SqlBuilder.Select<InnerOrmType>().Join.Left<OrmType>();
            const string expected = "left join OrmType on InnerOrmType.OrmTypeId = OrmType.Id";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToManyRelation()
        {
            var statement = SqlBuilder.Select<OrmType>().Join.Left<InnerOrmType>();
            const string expected = "left join InnerOrmType on OrmType.Id = InnerOrmType.OrmTypeId";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToOneRelation()
        {
            var statement = SqlBuilder.Select<AnotherOrmType>().Join.Left<OrmType>();
            const string expected = "left join OrmType on AnotherOrmType.OrmTypeId = OrmType.Id";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToManyRelationWhenChildrenIsArray()
        {
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Join.Left<InnerOrmType>();
            const string expected = "left join InnerOrmType on OrmTypeWithArray.Id = InnerOrmType.OrmTypeWithArrayId";
            statement.Sql.Should().Contain(expected);
        }

        [Test, ExpectedException(typeof (InvalidJoinException))]
        public void ThrowsExceptionWhenTypesNotContainsJoin()
        {
            SqlBuilder.Select<AnotherOrmType>().Join.Left<OrmTypeWithoutJoin>();
        }
    }
}