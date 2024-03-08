using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace csharp1.AOP
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public bool WillExecute { get; }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine(input.MethodBase.Name);//当前方法名
            //input.MethodBase.GetCustomAttributes();//判断特性
            foreach (var item in input.Inputs)
            {
                Console.WriteLine("方法执行前扩展");
                //if (...)//可以进行一些参数检验
                //{
                //    return input.CreateExceptionMethodReturn(new Exception("输入有误。。"));
                //}
            }
            //先执行BeforeBehavior的逻辑，再转到下一个，AfterBehavior反之
            return getNext().Invoke(input, getNext);
        }
    }
}
