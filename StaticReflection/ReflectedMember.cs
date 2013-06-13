namespace StaticReflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class ReflectedMember : IMember
    {
        private readonly MemberInfo _memberInfo;

        protected ReflectedMember(MemberInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        public string Name { get { return _memberInfo.Name; }}
   
        public Type DeclaringType {
            get { return _memberInfo.DeclaringType; }
        }

        public TAttribute GetCustomAttribute<TAttribute>() where TAttribute : Attribute
        {
            return _memberInfo.GetCustomAttribute<TAttribute>();
        }

        public Attribute GetCustomAttribute(Type tattribute)
        {
            return _memberInfo.GetCustomAttribute(tattribute);
        }

        public IEnumerable<Attribute> GetCustomerAttributes()
        {
            return _memberInfo.GetCustomAttributes();
        }

        public IEnumerable<Attribute> GetCustomerAttributes(bool inherit)
        {
            return _memberInfo.GetCustomAttributes(inherit).OfType<Attribute>();
        }

        public abstract Type MemberType { get; }
    }
}