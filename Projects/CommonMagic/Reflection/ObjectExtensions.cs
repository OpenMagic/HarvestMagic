using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CommonMagic.Reflection
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get PropertyInfo a property via LINQ expression.
        /// </summary>
        public static PropertyInfo Property<TObject, TProperty>(this TObject obj, Expression<Func<TObject, TProperty>> property)
        {
            if (property.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException(String.Format("Property must be NodeType '{0}', not '{1}'.", ExpressionType.Lambda, property.NodeType), "property");
            }

            if (property.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException(String.Format("Property's Body.NodeType must be '{0}', not '{1}'.", ExpressionType.MemberAccess, property.Body.NodeType), "property");
            }

            return (PropertyInfo)((MemberExpression)property.Body).Member;
        }
    }
}
