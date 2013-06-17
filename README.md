StaticReflection
================

Expression based Reflection library for .Net
---------------------------------------------

This is my version of the Lambda Expression approach to reflection.

It uses Lambda Expressions to access member information at runtime.

The core interfaces are 
* ``` IMemeber ``` the base interface that represents a type Member,
* ``` IGetSetMember ``` that abstract fields and property types, and
* ``` ICallableMember ```for Method member types

<dl>
    <dt>Basic Usage</dt>
    <dd></dd>
</dl>


```C#
    public class FunWithStaticReflection
    {
        private int _id = 0;
        
        public void ReflectMe()
        {
            var idField = this.GetMember(() => this._id);
            Console.Writeline(idField.Name); // displays "_id";
            Console.Writeline(this._id); // displays 0;
            var idSetter = idField as IGetSetMember;
            idSetter.SetValue(this, -2); 
            Console.Writeline(this._id); // displays -2;
            
            var nameProp = this.GetMember(() => this.Name);
            Console.Writeline(nameProp.Name); // displays "Name";
            Console.Writeline(this.Name); // displays "";
            var nameSetter = nameProp as IGetSetMember;
            nameSetter.SetValue(this, "Keyser Söze"); 
            Console.Writeline(this.Name); // displays "Keyser Söze";
                        
            var funMethod = this.GetMember(() => this.DoSomethingFun());
            Console.Writeline(funMethod.Name); // displays "DoSomethingFun";            
            var funInvoker = funMethod as ICallableMember;
            var everything = (int)funInvoker.Invoke(this, null);
            Console.Writeline(everything); // displays 42;
        }
        
        public string Name {get;set;}
        
        public int DoSomethingFun()
        {
            return 42;
        }
    }
```
