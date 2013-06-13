using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticReflection
{
    using System.Reflection;

    public static class MemberFactory
    {
        public static IMember GetMember(MemberInfo info)
        {
            if (info is FieldInfo)
            {
                return new FieldInfoDeafMember(info as FieldInfo);
            }
            if (info is PropertyInfo)
            {
                return new PropertyInfoDeafMember(info as PropertyInfo);
            }
            if (info is MethodInfo)
            {
                return new MethodInfoInvocableMember(info as MethodInfo);
            }
            
            throw new Exception("Unknown Member Info Type: " + info.GetType());
        }
    }
}
