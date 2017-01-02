
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StaticReflection
{    
    public class ArgumentEvaluatorExpressionVisitor : ExpressionVisitor
    {        
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
