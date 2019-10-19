using ATV_Allowance.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Helpers
{
    public static class LinqHelper
    {
        public static Func<T, bool> GetFilteredExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var member = Expression.Property(parameterExp, propertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);
            if (propertyType != typeof(string))
            {
                throw new NotSupportedException();
            }

            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, propertyType);
            var indexOf = Expression.Call(member, "IndexOf", null, someValue, Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
            var like = Expression.GreaterThanOrEqual(indexOf, Expression.Constant(0));
            var lambda = Expression.Lambda<Func<T, bool>>(like, parameterExp);

            return lambda.Compile();
        }
    }
}
