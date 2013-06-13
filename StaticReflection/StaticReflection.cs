
namespace StaticReflection
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class StaticReflection
    {
        public static IMember GetMember<TResult>(Expression<Func<TResult>> func)
        {
            return ParseAndGetMember(func.Body);
        }

        public static IMember GetMember<TType, TResult>(Expression<Func<TType,TResult>> func)
        {
            return ParseAndGetMember(func.Body);
        }

        public static IMember GetMember<TType>(Expression<Action<TType>> action)
        {
            return ParseAndGetMember(action.Body);
        }

        private static IMember ParseAndGetMember(Expression body)
        {
            if (body is MemberExpression)
            {
                return GetMember(body as MemberExpression);
            }
            if (body is MethodCallExpression)
            {
                var methodCall = body as MethodCallExpression;
                if (methodCall.Type == typeof(Delegate) && methodCall.Object is ConstantExpression)
                {
                    return new MethodInfoInvocableMember((MethodInfo) ((ConstantExpression) methodCall.Object).Value);
                }
                return GetCallableMember(body as MethodCallExpression);
            }
            if (body is UnaryExpression && body.NodeType == ExpressionType.Convert)
            {
                var unary = body as UnaryExpression;
                return ParseAndGetMember(unary.Operand);
            }

            throw new Exception("Expression must by a member access or method call expression");
        }

        private static IMember GetMember(MemberExpression memberExpression)
        {
            return MemberFactory.GetMember(memberExpression.Member);
        }
        
        private static ICallableMember GetCallableMember(MethodCallExpression expression)
        {
            return (ICallableMember)MemberFactory.GetMember(expression.Method);
        }
    }
}
