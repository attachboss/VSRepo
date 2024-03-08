using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace csharp1.AOP
{
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        public bool WillExecute { get; }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            //throw new NotImplementedException();
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //throw new NotImplementedException();
            IMethodReturn methodReturn = getNext()(input, getNext);//递归调用
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("没有出现异常");
            }
            else
            {
                Console.WriteLine($"异常信息：{methodReturn.Exception.Message}");
            }
            return methodReturn;
        }
    }
}
