using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace csharp1.Common
{
    public class ExpressionMapper
    {
        //静态字典缓存
        private static Dictionary<string, object> _dic = new Dictionary<string, object>();

        /// <summary>
        /// 建立对象映射
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tin"></param>
        /// <returns>返回TOut类型的映射对象</returns>
        public static TOut Mapping<TIn, TOut>(TIn tin)
        {
            string key = $"FuncKey_{typeof(TIn).FullName}_{typeof(TOut).FullName}";
            if (!_dic.ContainsKey(key))
            {
                ParameterExpression pe = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> mbList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression me = Expression.Property(pe, typeof(TIn).GetProperty(item.Name));
                    MemberBinding mb = Expression.Bind(item, me);
                    mbList.Add(mb);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression me = Expression.Field(pe, typeof(TIn).GetField(item.Name));
                    MemberBinding mb = Expression.Bind(item, me);
                    mbList.Add(mb);
                }
                MemberInitExpression mie = Expression.MemberInit(Expression.New(typeof(TOut)), mbList);
                Expression<Func<TIn, TOut>> lamb = Expression.Lambda<Func<TIn, TOut>>(mie, new ParameterExpression[] { pe });
                Func<TIn, TOut> func = lamb.Compile();
                _dic.Add(key, func);
            }
            return ((Func<TIn, TOut>)_dic[key]).Invoke(tin);
        }
    }


    public class ExpressionMapperGeneric<TIn, TOut>
    {
        //泛型缓存
        private static Func<TIn, TOut> _func = null;

        static ExpressionMapperGeneric()
        {

            ParameterExpression pe = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> mbList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression me = Expression.Property(pe, typeof(TIn).GetProperty(item.Name));
                MemberBinding mb = Expression.Bind(item, me);
                mbList.Add(mb);
            }
            foreach (var item in typeof(TOut).GetFields())
            {
                MemberExpression me = Expression.Field(pe, typeof(TIn).GetField(item.Name));
                MemberBinding mb = Expression.Bind(item, me);
                mbList.Add(mb);
            }
            MemberInitExpression mie = Expression.MemberInit(Expression.New(typeof(TOut)), mbList);
            Expression<Func<TIn, TOut>> lamb = Expression.Lambda<Func<TIn, TOut>>(mie, new ParameterExpression[] { pe });
            _func = lamb.Compile();
        }

        /// <summary>
        /// 泛型缓存对象映射
        /// </summary>
        /// <param name="tin"></param>
        /// <returns></returns>
        public static TOut Mapping(TIn tin)
        {
            return _func(tin);
        }
    }
}
