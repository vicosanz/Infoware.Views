using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infoware.Views.Attributes;

namespace Infoware.Views.Extensions
{
    public static class ShowAsAttributeExtensions
    {
        public static ShowAsAttribute GetShowAsAttribute(this object value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .OfType<ShowAsAttribute>()?
                .FirstOrDefault();
        }

        public static ShowAsAttribute GetShowAsAttribute(this PropertyInfo property)
        {
            return property
                .GetCustomAttribute<ShowAsAttribute>();
        }
    }
}
