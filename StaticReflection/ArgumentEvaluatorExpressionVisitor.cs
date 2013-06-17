

namespace StaticReflection
{

    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ArgumentEvaluatorExpressionVisitor : ExpressionVisitor
    {
        private int _depth = 0;
        private readonly List<object> _values = new List<object>();

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return base.VisitConstant(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            return base.VisitNew(node);
        }
    }
}
