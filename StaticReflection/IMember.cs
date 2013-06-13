namespace StaticReflection
{
    using System;
    using System.Collections.Generic;

    public interface IMember
    {
        /// <summary>
        /// Gets the name of this member
        /// </summary>
        string Name {get;}

        /// <summary>
        /// Gets the field, property or return type
        /// </summary>
        Type MemberType { get; }

        /// <summary>
        /// Gets the type that declares the current nested type or generic type parameter.
        /// </summary>
        Type DeclaringType { get; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}" /> of attributes applied to this member.
        /// </summary>
        IEnumerable<Attribute> GetCustomerAttributes();
        IEnumerable<Attribute> GetCustomerAttributes(bool inherit);

        /// <summary>
        /// Gets an instance of any attribute of <typeparamref name="TAttribute"/> applied to this member
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute</typeparam>
        /// <returns>An instance of <typeparamref name="TAttribute"/> applied to this member. If none are applied, returns null</returns>
        TAttribute GetCustomAttribute<TAttribute>() where TAttribute : Attribute;

        /// <summary>
        /// Gets an instance of any attribute of the <paramref name="tattribute"/> applied to this member
        /// </summary>
        /// <param name="tattribute">The type of attribute</param>
        /// <returns>An instance of <paramref name="tattribute"/> applied to this member. If none are applied, returns null</returns>
        Attribute GetCustomAttribute(Type tattribute);
    }
}