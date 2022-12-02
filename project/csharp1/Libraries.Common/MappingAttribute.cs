using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Common
{
    [AttributeUsage(AttributeTargets.All)]
    public class MappingAttribute : Attribute
    {
        private string _mappingName = null;
        public MappingAttribute(string mappingName)
        {
            this._mappingName = mappingName;
        }

        public string GetMappingName()
        {
            return _mappingName;
        }
    }


    public static class AttributeExtension
    {
        public static string GetMappingName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(MappingAttribute), true))
            {
                MappingAttribute attr = (MappingAttribute)prop.GetCustomAttribute(typeof(MappingAttribute), true);
                return attr.GetMappingName();
            }
            else
            {
                return prop.Name;
            }
        }
    }
}
