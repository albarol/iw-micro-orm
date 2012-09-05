namespace IwMicroOrm.Tests.Unit.Helpers
{
    using System;

    using IwMicroOrm.Core.Mapping;

    public class OrmType : IEntity<int>
    {
        public int Id { get; set; }
        public string OrmName { get; set; }
        public DateTime OrmDateTime { get; set; }
        public OrmType ParentOrmType { get; set; }
        public double OrmPrice { get { return 0d; } }
        public IManyRelation<InnerOrmType> InnerTypes { get; set; }
    }

    public class InnerOrmType : IEntity<int>
    {
        public int Id { get; set; }
        public double InnerOrmValue { get; set; }
        public OrmType Parent { get; set; }
    }

    public class AnotherOrmType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrmType OrmType { get; set; }
    }

    public class OrmTypeWithoutJoin : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrmTypeWithArray : IEntity<int>
    {
        public IManyRelation<InnerOrmType> InnerTypes { get; set; }
        public int Id { get; set; }
    }
}
