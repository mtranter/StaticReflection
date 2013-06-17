using System;
using System.IO;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc.Html;

namespace StaticReflection.Mvc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGenerateRouteValuesInAnchor()
        {
            var htmlHelper = new Mock<HtmlHelper>().Object;
           Expression<Func<TestController, ActionResult>> exp =  (TestController tc) =>
                    tc.SomeMethod(1, new DateTime(2000, 1, 1), TestRecursion(this.Value, new DateTime(2000, 1, 1)));
            var evaludator = new ExpressionEvaluator();
        }

        private string TestRecursion(string val, DateTime date)
        {
            return val + date.ToShortDateString();
        }

        public string Value
        {
            get { return "7"; }
        }
    }


    class TestController : Controller
    {

        public ActionResult SomeMethod(int id, DateTime date, string someWord)
        {
            return null;
        }

        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            
        }
    }




}
