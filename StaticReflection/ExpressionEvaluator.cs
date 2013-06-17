using System.Linq.Expressions;

namespace StaticReflection
{
    public class ExpressionEvaluator
    {
        public object Evaluate(Expression exp)
        {
            if (exp is ConstantExpression)
            {
                return ((ConstantExpression)exp).Value;
            }

            var lambda = Expression.Lambda(exp);
            var fn = lambda.Compile();
            return fn.DynamicInvoke(null);
        }
    }
}