using System;
using System.ComponentModel;

namespace Snap.Data.Utility.Extension
{
    public static class SupportInitializeExtensions
    {
        /// <summary>
        /// 将支持初始化的类型转化为可处理的类型
        /// 以支持更好的语法格式
        /// </summary>
        /// <param name="supportInitialize"></param>
        /// <returns></returns>
        public static IDisposable AsDisposableInit(this ISupportInitialize supportInitialize)
        {
            supportInitialize.BeginInit();
            return new SupportInitializeDisposable(supportInitialize);
        }

        private struct SupportInitializeDisposable : IDisposable
        {
            private readonly ISupportInitialize supportInitialize;

            public SupportInitializeDisposable(ISupportInitialize supportInitialize)
            {
                this.supportInitialize = supportInitialize;
            }

            public void Dispose()
            {
                supportInitialize.EndInit();
            }
        }
    }
}
