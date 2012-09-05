namespace IwMicroOrm.Tests.Unit.Query.Restrictions
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.Restrictions.Subqueries;
    using IwMicroOrm.Core.Query.SelectQuery;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    [Category("Restrictions")]
    [Ignore]
    public class SubqueryFixture
    {
        private ISelectQuery<OrmType> select;

        [SetUp]
        public void SetUp()
        {
            this.select = SqlBuilder.Select<OrmType>();
        }

        [Test]
        [Ignore]
        public void ShouldHaveConditionWhenIsSubQueryIn()
        {
            // Arrange:
            const string Expected = "Id in (select Id from OrmType)";

            // Act:
            this.select.Where(o => o.Id).In(SubQuery.CreateFrom<OrmType>(s => s.Id));

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }

        [Test]
        [Ignore]
        public void ShouldHaveConditionWhenIsSubQueryInWithRestriction()
        {
            // Arrange:
            const string Expected = "Id in (select Id from OrmType where Id = @IdEq)";
            
            // Act:
            this.select.Where(o => o.Id).In(SubQuery.CreateFrom<OrmType>(o => o.Id).Where(o => o.Id).NotEqual(1));

            // Assert:
            this.select.Sql.Should().Contain(Expected);
        }
        
        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryNotIn()
        //{
        //    select.Constraints.SubQuery.NotIn("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(o => o.Id));
        //    const string expected = "Id not in (select Id from OrmType)";
        //    select.Sql.Should().Contain(expected);
        //}

        
        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryNotInWithRestriction()
        //{
        //    select.Constraints.SubQuery.NotIn("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(e => e.Id).Constraints.Equal("Id").WithValue(1).EndConstraints);
        //    const string expected = "Id not in (select Id from OrmType where Id = @IdEq)";
        //    select.Sql.Should().Contain(expected);
        //}

        
        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryExists()
        //{
        //    select.Constraints.SubQuery.Exists("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(e => e.Id));
        //    const string expected = "Id exists (select Id from OrmType)";
        //    select.Sql.Should().Contain(expected);
        //}

        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryExistsWithRestriction()
        //{
        //    select.Constraints.SubQuery.Exists("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(e => e.Id).Constraints.Equal("Id").WithValue(1).EndConstraints);
        //    const string expected = "Id exists (select Id from OrmType where Id = @IdEq)";
        //    select.Sql.Should().Contain(expected);
        //}

        
        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryNotExists()
        //{
        //    select.Constraints.SubQuery.NotExists("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(e => e.Id));
        //    const string expected = "Id not exists (select Id from OrmType)";
        //    select.Sql.Should().Contain(expected);
        //}

        
        //[Test]
        //public void ShouldHaveConditionWhenIsSubQueryNotExistsWithRestriction()
        //{
        //    select.Constraints.SubQuery.NotExists("Id").With(SubQuery.CreateFrom<OrmType>().WithAttribute(e => e.Id).Constraints.Equal("Id").WithValue(1).EndConstraints);
        //    const string expected = "Id not exists (select Id from OrmType where Id = @IdEq)";
        //    select.Sql.Should().Contain(expected);
        //}
    }
}
