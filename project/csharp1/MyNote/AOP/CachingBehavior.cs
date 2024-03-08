using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace csharp1.AOP
{
    public class CachingBehavior : IInterceptionBehavior
    {
        public bool WillExecute => throw new NotImplementedException();

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            //throw new NotImplementedException();
            return Type.EmptyTypes;
        }

        private static Dictionary<string, object> CachingBehaviorDic = new Dictionary<string, object>();

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //throw new NotImplementedException();
            string key = $"{input.MethodBase.Name}_{JsonSerializer.Serialize(input.Inputs)}";
            if (CachingBehaviorDic.ContainsKey(key))
            {
                //字典中存在时直接返回 断路器
                return input.CreateMethodReturn(CachingBehaviorDic[key]);
            }
            else
            {
                //字典中不存在时添加
                IMethodReturn res = getNext()(input, getNext);
                if (res.ReturnValue != null)
                    CachingBehaviorDic.Add(key, res.ReturnValue);
                return res;
            }
        }
    }
}
