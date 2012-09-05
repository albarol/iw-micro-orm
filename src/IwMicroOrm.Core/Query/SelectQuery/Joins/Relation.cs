namespace IwMicroOrm.Core.Query.SelectQuery.Joins
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal class Relation
    {
        public static RelationType GetRelationBetweenTypes(Type innerType, Type foreignType)
        {
            var properties = innerType.GetProperties();
            if (properties.Any(property => property.PropertyType == foreignType))
            {
                return RelationType.OneToOne;
            }

            if (ContainsManyRelation(properties, foreignType))
            {
                return RelationType.OneToMany;
            }

            throw new InvalidJoinException("This statement does not contain a real join.");
        }

        private static bool ContainsManyRelation(PropertyInfo[] innerProperties, Type foreignType)
        {
            bool contains = false;

            for (int i = 0; i < innerProperties.Length && !contains; i++)
            {
                var property = innerProperties[i];
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericArguments().Any(a => a == foreignType))
                    contains = true;
                if (property.PropertyType.IsArray && property.PropertyType.GetElementType() == foreignType)
                    contains = true;
            }
            return contains;
        }

        //public static void AssignJoinMappingInSelect(ISelectQuery select, JoinStatementSql statement)
        //{
        //    var fieldInfo = typeof(Select<>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name.Equals("JoinMapping"));
        //    fieldInfo.SetValue(select, statement);
        //}
    }
}
