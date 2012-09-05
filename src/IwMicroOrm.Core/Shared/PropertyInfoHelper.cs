using IwMicroOrm.Core.Mapping;

namespace IwMicroOrm.Core.Shared
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class PropertyInfoHelper
    {
        internal static PropertyInfo GetPropertyFromExpression<T>(Expression<Func<T, object>> expression)
        {
            MemberExpression memberExpression = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
                memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Not a member access", "expression");
            return memberExpression.Member as PropertyInfo;
        }

        internal static T[] JoinArrays<T>(T[] firstArray, T[] secondArray)
        {
            var joinedArray = new T[firstArray.Length + secondArray.Length];
            for (int index = 0; index < firstArray.Length; ++index)
                joinedArray[index] = firstArray[index];
            for (int index = 0; index < secondArray.Length; ++index)
                joinedArray[index + firstArray.Length] = secondArray[index];
            return joinedArray;
        }

        internal static PropertyInfo[] GetEntityProperties(object entity)
        {
            string entityIdentifierName = typeof (IEntity<>).GetProperties().First().Name;
            return entity.GetType().GetProperties().Where(p => p.CanWrite && p.Name != entityIdentifierName && !IsComplexType(p.PropertyType)).ToArray();
        }

        internal static bool IsManyRelation(Type type)
        {
            if (type.IsArray) return true;
            if (typeof(ICollection).IsAssignableFrom(type)) return true;
            if (type.IsGenericType)
                return type.GetInterfaces().Any(interfaceType => interfaceType.GetGenericTypeDefinition() == typeof(ICollection<>));
            return false;
        }

        internal static bool IsComplexType(Type type)
        {
            if (type.IsEnum) return false;
            if (type.IsValueType) return false;
            if (typeof(String) == type) return false;
            if (typeof(DateTime) == type) return false;
            return true;
        }

    }
}
