using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MZExtensions
{
    public static class FuncEx
    {
        public static Func<TRes> Create<TRes>(Func<TRes> f)
        {
            return f;
        }
        public static Func<TArg1, TRes> Create<TArg1, TRes>(Func<TArg1, TRes> f)
        {
            return f;
        }
        public static Func<TArg1, TArg2, TRes> Create<TArg1, TArg2, TRes>(Func<TArg1, TArg2, TRes> f)
        {
            return f;
        }
        public static Func<TArg1, TArg2, TArg3, TRes> Create<TArg1, TArg2, TArg3, TRes>(Func<TArg1, TArg2, TArg3, TRes> f)
        {
            return f;
        }
    }
}