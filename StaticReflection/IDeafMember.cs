namespace StaticReflection
{
    public interface IDeafMember : IMember
    {

        bool IsReadonly { get; }

        /// <summary>
        /// Returns the property value of a specified object with optional index values for indexed properties.
        /// </summary>
        /// <param name="instance">The object whose property value will be returned.</param>
        /// <returns>Optional index values for indexed properties. This value should be null for non-indexed properties.</returns>
        object GetValue(object instance);

        /// <summary>
        /// Sets the property value of a specified object.
        /// </summary>
        /// <param name="instance">The object whose property value will be set.</param>
        /// <param name="value">The new property value.</param>
        void SetValue(object instance, object value);
    }
}