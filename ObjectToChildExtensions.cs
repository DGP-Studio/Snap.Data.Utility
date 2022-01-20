using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Snap.Data.Utility
{
    public static partial class ObjectToChildExtensions
    {
        /// <summary>
        /// 将父类对象的属性复制到新创建的子类实例
        /// 使用此方法时 <typeparamref name="TParent"/> 与 <typeparamref name="TChild"/> 中不应存在类索引器
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        [return: NotNullIfNotNull("parent")]
        public static TChild? ToChild<TParent, TChild>(this TParent parent, Action<TChild>? additionalModifier = null) where TChild : TParent, new()
        {
            if (parent != null)
            {
                TChild child = new();
                foreach (PropertyInfo parentProp in parent.GetType().GetProperties())
                {
                    if (parentProp.GetCustomAttribute<IgnoreInToChildAttribute>() != null)
                    {
                        continue;
                    }
                    PropertyInfo? childProp = child.GetType().GetProperty(parentProp.Name);
                    if (childProp?.CanWrite == true)
                    {
                        childProp.SetValue(child, parentProp.GetValue(parent, null), null);
                    }
                }
                additionalModifier?.Invoke(child);
                return child;
            }
            return default;
        }
    }
}
