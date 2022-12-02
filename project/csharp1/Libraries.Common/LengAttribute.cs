using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LengAttribute : Attribute
    {
        private int _max = 0;
        private int _min = 0;

        public LengAttribute(int min, int max)
        {
            this._min = min;
            this._max = max;
        }

        /// <summary>
        /// 验证字符串长度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int length = value.ToString().Length;
                if (length < this._max && length > this._min)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
