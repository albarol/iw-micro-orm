namespace IwMicroOrm.Tests.Unit.Query
{
    using System;

    using IwMicroOrm.Core.Query;
    using IwMicroOrm.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture, Category("Statements")]
    public class InsertFixture
    {
        [Test]
        public void Insert_ShouldConstructInsertStatementFromOrmType()
        {
            // Arrange:
            const string Expected = "insert into OrmType(OrmName,OrmDateTime) values(@OrmName,@OrmDateTime)";
            var ormType = new OrmType
            {
                Id = 1,
                OrmName = "IwMicroOrm",
                OrmDateTime = DateTime.Now,
                ParentOrmType = new OrmType()
            };

            // Act:
            var statement = SqlBuilder.Insert(ormType);
            
            
            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Insert_ShouldConstructInsertStatementFromAnotherOrmType()
        {
            // Arrange:
            const string Expected = "insert into AnotherOrmType(Name) values(@Name)";
            var anotherOrmType = new AnotherOrmType
            {
                Id = 1,
                Name = "AnotherOrmType",
                OrmType = new OrmType()
            };

            // Act:
            var statement = SqlBuilder.Insert(anotherOrmType);
            
            
            // Assert:
            statement.Sql.Should().Be.EqualTo(Expected);
        }

        [Test]
        public void Insert_ShouldHaveParametersWhenBuildStatement()
        {
            // Arrange:
            var anotherOrmType = new AnotherOrmType
            {
                Id = 1,
                Name = "AnotherOrmType",
                OrmType = new OrmType()
            };

            // Act:
            var statement = SqlBuilder.Insert(anotherOrmType);
            var parameters = statement.Parameters;


            // Assert:
            parameters.Length.Should().Be.EqualTo(1);
            parameters[0].Column.Should().Be.EqualTo("@Name");
            parameters[0].Value.Should().Be.EqualTo(anotherOrmType.Name);
        }

    }
}
