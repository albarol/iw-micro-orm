namespace IwMicroOrm.Tests.Unit.Query.Joins
{
    using System;

    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.SelectQuery.Joins;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Select.Join")]
    public class LeftOuterJoinFixture
    {
        [Test]
        public void ShouldFindManyToOneRelation()
        {
            var statement = SqlBuilder.Select<InnerOrmType>().Join.LeftOuter<OrmType>();
            const string expected = "left outer join OrmType on InnerOrmType.OrmTypeId = OrmType.Id";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToManyRelation()
        {
            var statement = SqlBuilder.Select<OrmType>().Join.LeftOuter<InnerOrmType>();
            const string expected = "left outer join InnerOrmType on OrmType.Id = InnerOrmType.OrmTypeId";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToOneRelation()
        {
            var statement = SqlBuilder.Select<AnotherOrmType>().Join.LeftOuter<OrmType>();
            const string expected = "left outer join OrmType on AnotherOrmType.OrmTypeId = OrmType.Id";
            statement.Sql.Should().Contain(expected);
        }

        [Test]
        public void ShouldFindOneToManyRelationWhenChildrenIsArray()
        {
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Join.LeftOuter<InnerOrmType>();
            const string expected = "left outer join InnerOrmType on OrmTypeWithArray.Id = InnerOrmType.OrmTypeWithArrayId";
            statement.Sql.Should().Contain(expected);
        }
        
        [Test, ExpectedException(typeof (InvalidJoinException))]
        public void ThrowsExceptionWhenTypesNotContainsJoin()
        {
            SqlBuilder.Select<AnotherOrmType>().Join.LeftOuter<OrmTypeWithoutJoin>();
        }
    }
}