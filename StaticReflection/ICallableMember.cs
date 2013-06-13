namespace StaticReflection
{
    public interface ICallableMember : IMember
    {
        /// <summary>
        /// Invokes the method or constructor represented by the current instance, using the specified parameters.
        /// </summary>
        /// <param name="instance">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be null or an instance of the class that defines the constructor.</param>
        /// <param name="params">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, parameters should be null.</param>
        /// <returns>An object containing the return value of the invoked method.</returns>
        object Invoke(object instance, object[] @params);
    }
}