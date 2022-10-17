using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Common
{

    public static class ValidateExtension
    {
        public static bool Validate(this object value)
        {
            Type type = value.GetType();
            foreach (var item in type.GetProperties())
            {
                if (item.IsDefined(typeof(LengAttribute), true))
                {
                    LengAttribute attr = (LengAttribute)item.GetCustomAttribute(typeof(LengAttribute), true);
                    if (!attr.Validate(item.GetValue(value)))
                    {
                        throw new Exception($"{item.Name}属性长度验证未通过");
                    }
                }
                if (item.IsDefined(typeof(RegexAttribute), true))
                {
                    RegexAttribute attr = (RegexAttribute)item.GetCustomAttribute(typeof(RegexAttribute), true);
                    if (!attr.Validate(item.GetValue(value)))
                    {
                        throw new Exception($"{item.Name}属性验证未通过");
                    }
                }
            }
            return true;
        }
    }
}
