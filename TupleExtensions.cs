using Snap.Data.Primitive;
using System;

namespace Snap.Data.Utility
{
    public static class TupleExtensions
    {
        /// <summary>
        /// <see cref="Nullable{T}"/> To Tuple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nullable"></param>
        /// <param name="hasValue"></param>
        /// <param name="value"></param>
        public static void Deconstruct<T>(this T? nullable, out bool hasValue, out T value) where T : struct
        {
            hasValue = nullable.HasValue;
            value = nullable.GetValueOrDefault();
        }
    }
}
