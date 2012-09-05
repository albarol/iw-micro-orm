namespace IwMicroOrm.Tests.Unit.Query
{
    using System;

    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class UpdateFixture
    {
        [Test]
        public void Update_ShouldConstructUpdateStatementFromOrmType()
        {
            // Arrange:
            const string expected = "update OrmType set OrmName = @OrmName, OrmDateTime = @OrmDateTime";
            var ormType = new OrmType
            {
                Id = 1,
                OrmName = "IwMicroOrm",
                OrmDateTime = DateTime.Now,
                ParentOrmType = new OrmType()
            };


            // Act:
            var statement = SqlBuilder.Update(ormType);


            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Update_ShouldConstructUpdateStatementFromAnotherOrmType()
        {
            // Arrange:
            var anotherOrmType = new AnotherOrmType
            {
                Id = 1,
                Name = "AnotherOrmType",
                OrmType = new OrmType()
            };
            const string expected = "update AnotherOrmType set Name = @Name where Id = @IdEq";

            // Act:
            var statement = SqlBuilder.Update(anotherOrmType).Where(a => a.Id).Equal(1);

            // Assert:
            statement.Sql.Should().Be.EqualTo(expected);
        }

        [Test]
        public void Update_ShouldHaveParameterWhenStatementDontHaveRestrictions()
        {
            // Arrange:
            var anotherOrmType = new AnotherOrmType
            {
                Id = 1,
                Name = "AnotherOrmType",
                OrmType = new OrmType()
            };

            // Act:
            var statement = SqlBuilder.Update(anotherOrmType);
            var parameters = statement.Parameters;

            // Assert:
            parameters.Length.Should().Be.EqualTo(1);
            parameters[0].Column.Should().Be.EqualTo("@Name");
            parameters[0].Value.Should().Be.EqualTo(anotherOrmType.Name);
        }

        [Test]
        public void Update_ShouldHaveParameterWhenStatementHaveRestrictions()
        {
            // Arrange:
            var anotherOrmType = new AnotherOrmType
            {
                Id = 1,
                Name = "AnotherOrmType",
                OrmType = new OrmType()
            };

            // Act:
            var statement = SqlBuilder.Update(anotherOrmType).Where(a => a.Id).Equal(1);
            var parameters = statement.Parameters;

            // Assert:
            parameters.Length.Should().Be.EqualTo(2);
        }

    }
}
