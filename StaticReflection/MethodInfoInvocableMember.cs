namespace StaticReflection
{
    using System;
    using System.Reflection;

    public class MethodInfoInvocableMember : ReflectedMember, ICallableMember
    {
        private readonly MethodInfo _methodInfo;

        public MethodInfoInvocableMember(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public override Type MemberType
        {
            get { return _methodInfo.ReturnType; }
        }

        #region ICallableMember Members

        public object Invoke(object instance, object[] @params)
        {
            return _methodInfo.Invoke(instance, @params);
        }

        #endregion
    }
}