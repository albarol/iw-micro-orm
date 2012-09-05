using System;
using IwMicroOrm.Core.Query.Restrictions.Subqueries;
using IwMicroOrm.Core.Query.SelectQuery;

namespace IwMicroOrm.Tests.Unit.Query
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Statements")]
    public class SelectFixture
    {
        #region Basic Statements

        [Test, Ignore("Test String Statement")]
        public void Select_ShowSqlGenerated()
        {
            var statement = SqlBuilder.Select<InnerOrmType>().Join.Inner<OrmType>()
                                      .Where(i => i.Id).Equal(1).Or.Where(i => i.Id).Between(10, 15)
                                      .And.Where(i => i.InnerOrmValue).Like("%IwMicroOrm")
                                      .Or.Where(i => i.Id).In(SubQuery.CreateFrom<OrmType>(i => i.Id))
                                      .And.Where(i => i.Id).Greater(1)
                                      .Order.Ascending(i => i.Id);
            const string expected = "select Id, InnerOrmValue, Parent from InnerOrmType"
                                    + " inner join OrmType on InnerOrmType.OrmTypeId = OrmType.Id"
                                    + " where Id = @IdEq or Id between @IdBtBegin and @IdBtEnd and InnerOrmValue like @InnerOrmValueLike"
                                    + " or Id in (select Id from OrmType) and Id > @IdGt"
                                    + " order by Id asc";
            statement.Sql.Should().Be.EqualTo(expected);
            Console.WriteLine(statement.Sql);
        }

        [Test]
        public void Select_ShouldTransformInnerOrmTypeInSelectStatement()
        {
            // Arrange:
            const string Expected = "select Id, InnerOrmValue, Parent from InnerOrmType";

            // Act:
            var statement = SqlBuilder.Select<InnerOrmType>();

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Select_WhenPropertyCantReadShouldBeIgnored()
        {
            // Arrange:
            const string Expected = "select Id, OrmName, OrmDateTime, ParentOrmType from OrmType";

            // Act:
            var statement = SqlBuilder.Select<OrmType>();

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Select_WhenPropertyIsListShouldBeIgnored()
        {
            // Arrange:
            const string Expected = "select Id, InnerOrmValue, Parent from InnerOrmType";

            // Act:
            var statement = SqlBuilder.Select<InnerOrmType>();

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Select_WhenPropertyIsArrayShouldBeIgnored()
        {
            // Arrange:
            const string Expected = "select Id from OrmTypeWithArray";

            // Act:
            var statement = SqlBuilder.Select<OrmTypeWithArray>();

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Select_ShouldCanSelectSomeProperties()
        {
            // Arrange:
            const string Expected = "select Id, OrmName from OrmType";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Property(o => o.Id), Field<OrmType>.Property(o => o.OrmName));

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        #endregion

        #region Join Statements

        [Test]
        public void Select_WhenPropertyIsListShouldHaveInnerJoin()
        {
            // Arrange:
            const string Expected = "select Id, OrmName, OrmDateTime, ParentOrmType from OrmType inner join InnerOrmType on OrmType.Id = InnerOrmType.OrmTypeId";
            
            // Act:
            var statement = SqlBuilder.Select<OrmType>().Join.Inner<InnerOrmType>();
            
            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Select_WhenPropertyIsParentShouldHaveInnerJoin()
        {
            // Arrange:
            const string Expected = "select Id, InnerOrmValue, Parent from InnerOrmType left join OrmType on InnerOrmType.OrmTypeId = OrmType.Id";

            // Act:
            var statement = SqlBuilder.Select<InnerOrmType>().Join.Left<OrmType>();
            
            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        #endregion

        #region Function Statements

        [Test]
        public void Functions_ShouldDistinctFunctionInStatement()
        {
            // Arrange:
            const string expected = "select distinct(Id), OrmName from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Distinct(f => f.Id), Field<OrmType>.Property(t => t.OrmName)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Functions_ShouldCountFunctionInStatement()
        {
            // Arrange:
            const string expected = "select count(Id) from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Count(o => o.Id)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Functions_ShouldAvgFunctionInStatement()
        {
            // Arrange:
            const string expected = "select avg(Id) from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Avg(o => o.Id)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Functions_ShouldSumFunctionInStatement()
        {
            // Arrange:
            const string expected = "select sum(Id) from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Sum(o => o.Id)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Functions_ShouldMinFunctionInStatement()
        {
            // Arrange:
            const string expected = "select min(Id) from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select<OrmType>(Field<OrmType>.Min(o => o.Id)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Functions_ShouldMaxFunctionInStatement()
        {
            // Arrange:
            const string expected = "select max(Id) from OrmType group by Id";

            // Act:
            var statement = SqlBuilder.Select(Field<OrmType>.Max(o => o.Id)).GroupBy(o => o.Id);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }


        #endregion

        #region Constrains Statements

        [Test]
        public void Restrictions_WhenAddRestrictionShouldHaveConstrains()
        {
            // Arrange:
            const string expected = "select Id from OrmTypeWithArray where Id = @IdEq";

            // Act:
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Where(o => o.Id).Equal(1);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Restrictions_WhenAddRestrictionShouldHaveSubQueries()
        {
            // Arrange:
            const string expected = "select Id from OrmTypeWithArray where Id in (select Id from OrmType)";
            
            // Act:
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Where(i => i.Id).In(SubQuery.CreateFrom<OrmType>(o => o.Id));
            
            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Restrictions_ShouldHaveParametersWhenStatementContainsRestrictions()
        {
            // Arrange:
            const int numberOfParameters = 2;

            // Act:
            var statement = SqlBuilder.Select<OrmTypeWithArray>().Where(i => i.Id).Greater(1)
                                                                 .And.Where(i => i.Id).Less(10);

            // Assert:
            statement.Parameters.Length.Should().Be.EqualTo(numberOfParameters);
        }

        #endregion
    }
}