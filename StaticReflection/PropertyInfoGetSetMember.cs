﻿namespace StaticReflection
{
    using System;
    using System.Reflection;

    public class PropertyInfoGetSetMember : ReflectedMember,  IGetSetMember
    {
        private readonly PropertyInfo _propertyInfo;

        public PropertyInfoGetSetMember(PropertyInfo propertyInfo)
            : base(propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public override Type MemberType
        {
            get { return _propertyInfo.PropertyType; }
        }

        #region IDeafMember Members

        public bool IsReadonly
        {
            get { return !_propertyInfo.CanWrite; }
        }

        public object GetValue(object instance)
        {
            return _propertyInfo.GetValue(instance);
        }

        public void SetValue(object instance, object value)
        {
            _propertyInfo.SetValue(instance, value);
        }

        #endregion
    }
}