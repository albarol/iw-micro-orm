namespace IwMicroOrm.Tests.Unit.Query
{
    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Core.Query.Restrictions.Subqueries;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Statements")]
    public class DeleteFixture
    {
        [Test]
        public void Delete_ShouldTransformInnerOrmTypeInDeleteStatement()
        {
            // Arrange:
            const string Expected = "delete from InnerOrmType";

            // Act:
            var statement = SqlBuilder.Delete<InnerOrmType>();

            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Delete_WhenAddRestrictionShouldHaveConstrains()
        {
            // Arrange:
            const string Expected = "delete from OrmTypeWithArray where Id = @IdEq and InnerTypes between @InnerTypesBtBegin and @InnerTypesBtEnd or Id = 1";
            

            // Act:
            var statement = SqlBuilder.Delete<OrmTypeWithArray>().Where(t => t.Id).Equal(1)
                                                                 .And.Where(t => t.InnerTypes).Between(2, 3)
                                                                 .Or.Where("Id = 1");
            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Delete_WhenAddRestrictionShouldHaveSubQueries()
        {
            //Arrange:
            const string expected = "delete from OrmTypeWithArray where Id in (select Id from OrmType)";
            
            //Act:
            var statement = SqlBuilder.Delete<OrmTypeWithArray>().Where(o => o.Id).In(SubQuery.CreateFrom<OrmType>(o => o.Id));
            
            //Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Delete_WhenAddRestrictionsShoulHaveParameters()
        {
            //Arrange:
            Parameter[] expected = new[] {new Parameter{ Column = "@IdEq", Value = 1}};

            //Act:
            var statement = SqlBuilder.Delete<OrmTypeWithArray>().Where(o => o.Id).Equal(1);
            var parameters = statement.Parameters;

            //Assert:
            parameters.Length.Should().Be.EqualTo(expected.Length);
            parameters[0].Value.Should().Be.EqualTo(expected[0].Value);
            parameters[0].Column.Should().Be.EqualTo(expected[0].Column);
        }
    }
}
