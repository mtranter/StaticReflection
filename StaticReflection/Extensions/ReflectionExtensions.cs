
namespace StaticReflection.Extensions
{
    using System;
    using System.Linq.Expressions;

    public static class ReflectionExtensions
    {
        public static IMember GetMember<TTarget, TResult>(this TTarget target, Expression<Func<TResult>> func)
        {
            return StaticReflection.GetMember(func);
        }

        public static IMember GetMember<TTarget, TResult>(this TTarget target, Expression<Func<TTarget, TResult>> func)
        {
            return StaticReflection.GetMember(func);
        }

        public static IMember GetMember<TTarget>(this TTarget target, Expression<Action<TTarget>> action)
        {
            return StaticReflection.GetMember(action);
        }
    }
}
