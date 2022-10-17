using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libraries.Common
{
    [AttributeUsage(AttributeTargets.All)]
    public class RegexAttribute : Attribute
    {
        public RegexAttribute(string regex)
        {
            this._regex = regex;
        }
        private string _regex = String.Empty;

        public bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                return Regex.IsMatch(value.ToString(), this._regex);

            }
            return false;
        }
    }

}
