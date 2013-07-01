
using System;
using System.Linq.Expressions;

namespace StaticReflection
{
    public static class ReflectOn<TSource>
    {
        public static IMember Member<TMember>(Expression<Func<TSource, TMember>> member)
        {
            return StaticReflection.GetMember(member);
        }

        public static IMember Member(Expression<Action<TSource>> member)
        {
            return StaticReflection.GetMember(member);
        }
    }
}
