
namespace StaticReflection.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;


    public static class MvcHelperExtensions
    {

        public static MvcHtmlString ActionFor<TController>(this HtmlHelper helper, Expression<Func<TController, ActionResult>> actionDef)
            where TController : IController
        {
            var method = StaticReflection.GetMember(actionDef) as ICallableMember;
            var controller = method.DeclaringType.Name.Replace("Controller", "");
            var methodExp = actionDef.Body as MethodCallExpression;
            var routeVals = GetRouteValuesFromMethodCall(methodExp);
            return helper.Action(method.Name, controller, routeVals);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, Expression<Func<TController, ActionResult>> actionDef, bool generateRouteValues = true)
            where TController : IController
        {
            return ActionLinkFor(helper, actionDef, null, generateRouteValues);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, Expression<Func<TController, ActionResult>> actionDef, object htmlAttributes, bool generateRouteValues = true)
            where TController : IController
        {
            return ActionLinkFor(helper, actionDef, new RouteValueDictionary(htmlAttributes), generateRouteValues);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, Expression<Func<TController, ActionResult>> actionDef, IDictionary<string,object> htmlAttributes, bool generateRouteValues = true)
            where TController : IController
        {
            var method = StaticReflection.GetMember(actionDef) as ICallableMember;
            var display = method.GetCustomAttribute<DisplayAttribute>();
            var text = display != null ? display.GetName() ?? method.Name : method.Name;
            var methodExp = actionDef.Body as MethodCallExpression;
            IDictionary<string, object> routeVals = null;
            if (generateRouteValues)
                routeVals = GetRouteValuesFromMethodCall(methodExp);
            return helper.ActionLinkFor(text, actionDef, new RouteValueDictionary(routeVals), htmlAttributes);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, string text, Expression<Func<TController, ActionResult>> actionDef)
            where TController : IController
        {
            return helper.ActionLinkFor(text, actionDef, null, null);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, string text, Expression<Func<TController, ActionResult>> actionDef,
                                                       object routeValues)
            where TController : IController
        {
            return helper.ActionLinkFor(text, actionDef, routeValues, null);
        }

        public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, string text, Expression<Func<TController, ActionResult>> actionDef,
                                                       object routeValues,
                                                       object htmlAttributes)
            where TController : IController
        {
            return helper.ActionLinkFor(text, actionDef, routeValues, new RouteValueDictionary(htmlAttributes));
        }

       public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, string text, Expression<Func<TController, ActionResult>> actionDef,
                                                              object routeValues,
                                                              IDictionary<string, object> htmlAttributes)
           where TController : IController
       {
           return helper.ActionLinkFor(text, actionDef, new RouteValueDictionary(routeValues), htmlAttributes);
       }

       public static MvcHtmlString ActionLinkFor<TController>(this HtmlHelper helper, string text, Expression<Func<TController, ActionResult>> actionDef,
                                                      RouteValueDictionary routeValues,
                                                      IDictionary<string, object> htmlAttributes)
           where TController : IController
       {
           var member = StaticReflection.GetMember(actionDef) as ICallableMember;
           var controller = member.DeclaringType.Name.Replace("Controller", "");
           var action = member.Name;
           return helper.ActionLink(text, action, controller, routeValues, htmlAttributes);
       }

        private static IDictionary<string, object> GetRouteValuesFromMethodCall(MethodCallExpression exp)
        {
            var methodInfo = exp.Method;
            var evaluator = new ExpressionEvaluator();
            var names = methodInfo.GetParameters().Select(p => p.Name).ToArray();
            var vals = exp.Arguments.Select(evaluator.Evaluate).ToArray();
            
            var retval = new Dictionary<string, object>();
            for (var i = 0; i < names.Length; i++)
            {
                retval.Add(names[i], vals[i]);
            }

            return retval;
        }
    
    }
}
