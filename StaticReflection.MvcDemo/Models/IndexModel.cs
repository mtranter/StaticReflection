using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaticReflection.MvcDemo.Models
{
    public class IndexModel
    {
        public DateTime GetMyBirthday(bool someVal)
        {
            return new DateTime(1979, 12, 1);
        }
    }
}