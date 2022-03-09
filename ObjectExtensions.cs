using Snap.Reflection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Snap.Data.Utility
{
    public static partial class ObjectExtensions
    {
        /// <summary>
        /// 将父类对象的属性复制到新创建的子类实例
        /// 使用此方法时 <typeparamref name="TParent"/> 与 <typeparamref name="TChild"/> 中不能存在类索引器 this[]
        /// 会忽略带有 <see cref="IgnoreInToChildAttribute"/> 特性的属性
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="parent"></param>
        /// <param name="additionalModifier">拷贝完成后执行的额外操作</param>
        /// <returns></returns>
        [return: NotNullIfNotNull("parent")]
        public static TChild? ToChild<TParent, TChild>(this TParent parent, Action<TChild>? additionalModifier = null) where TChild : TParent, new()
        {
            if (parent != null)
            {
                TChild child = new();

                parent.ForEachPropertyInfoWithoutAttribute<IgnoreInToChildAttribute>(parentProp =>
                child.SetPropertyValueByName(parentProp.Name, parent.GetPropertyValueByInfo(parentProp)));

                additionalModifier?.Invoke(child);
                return child;
            }
            return default;
        }

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
