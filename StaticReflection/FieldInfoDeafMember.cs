namespace StaticReflection
{
    using System;
    using System.Reflection;

    public class FieldInfoDeafMember : ReflectedMember, IDeafMember
    {
        private readonly FieldInfo _fieldInfo;

        public FieldInfoDeafMember(FieldInfo fieldInfo)
            : base(fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }

        public override Type MemberType
        {
            get { return _fieldInfo.FieldType; }
        }

        #region IDeafMember Members

        public bool IsReadonly
        {
            get { return false; }
        }

        public object GetValue(object instance)
        {
            return _fieldInfo.GetValue(instance);
        }

        public void SetValue(object instance, object value)
        {
            _fieldInfo.SetValue(instance, value);
        }

        #endregion
    }
}