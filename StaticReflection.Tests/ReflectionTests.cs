

namespace StaticReflection.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    
    

    [TestClass]
    public class ReflectionTests
    {
        private int _testField;

        protected internal int ProtectedProperty { get; set; }

        private int TestFunc(DateTime date, int i, double d)
        {
            return _testField;
        }

        [TestMethod]
        public void canGetFieldInfo()
        {
            var member = StaticReflection.GetMember(() => this._testField);
            Assert.AreEqual(member.Name, "_testField");
            Assert.IsTrue(member is IGetSetMember);
        }

        [TestMethod]
        public void canGetPropertyInfo()
        {
            var member = StaticReflection.GetMember(() => this.ProtectedProperty);
            Assert.AreEqual(member.Name, "ProtectedProperty");
            Assert.IsTrue(member is IGetSetMember);
        }

        [TestMethod]
        public void canGetMethodInfo()
        {
            var member = StaticReflection.GetMember(() => this.TestFunc(DateTime.Now, 1,1));
            Assert.AreEqual(member.Name, "TestFunc");
            Assert.IsTrue(member is ICallableMember);
        }

        [TestMethod]
        public void canGetFieldValue()
        {
            var member = StaticReflection.GetMember(() => this._testField) as IGetSetMember;
            Assert.IsNotNull(member);
            _testField = 42;
            var value = member.GetValue(this);
            Assert.AreEqual(value, 42);
        }

        [TestMethod]
        public void canSetFieldValue()
        {
            var member = StaticReflection.GetMember(() => this._testField) as IGetSetMember;
            Assert.IsNotNull(member);
            _testField = 1;
            member.SetValue(this, 42);
            Assert.AreEqual(_testField, 42);
        }

        [TestMethod]
        public void canGetPropertyValue()
        {
            var member = StaticReflection.GetMember(() => this.ProtectedProperty) as IGetSetMember;
            Assert.IsNotNull(member);
            ProtectedProperty = 42;
            var value = member.GetValue(this);
            Assert.AreEqual(value, 42);

        }

        [TestMethod]
        public void canSetPropertyValue()
        {
            var member = StaticReflection.GetMember(() => this.ProtectedProperty) as IGetSetMember;
            Assert.IsNotNull(member);
            ProtectedProperty = 42;
            var value = member.GetValue(this);
            Assert.AreEqual(value, 42);
        }

        [TestMethod]
        public void canInvokeMethod()
        {
            var member = StaticReflection.GetMember(() => this.TestFunc(DateTime.Now, 1, 1)) as ICallableMember;
            Assert.IsNotNull(member);
            _testField = 42;
            var val = (int) member.Invoke(this, new object[]{ DateTime.Now, 1, 2});
            Assert.AreEqual(val, 42);
        }

        [TestMethod]
        public void canReflectOn()
        {
            var member = ReflectOn<ReflectionTests>.Member(t => t.ProtectedProperty);
            Assert.IsNotNull(member);
            Assert.AreEqual(member.Name, "ProtectedProperty");
        }
    }
}
