using System.Collections.Generic;

namespace Snap.Data.Utility.Extension
{
    public static class TupleExtensions
    {
        /// <summary>
        /// 将二项元组转化为一个单项的字典
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static IDictionary<T1, T2> AsDictionary<T1, T2>(this (T1 Key, T2 Value) tuple)
            where T1 : notnull
        {
            return new Dictionary<T1, T2>(1) { { tuple.Key, tuple.Value } };
        }
    }
}
