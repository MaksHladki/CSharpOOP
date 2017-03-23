using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator.Core.Attribute;
using Validator.Core.Attribute.Validation;

namespace Validator.Core.Extension
{
    public static class PropertyInfoExtension
    {
        public static string GetDisplayName(this PropertyInfo prop)
        {
            var displayAttr = prop.GetCustomAttribute(typeof(DisplayAttribute));
            return displayAttr != null ? ((DisplayAttribute)displayAttr).Name : prop.Name;
        }

        public static IEnumerable<BaseValidateAttribute> GetValidationAttributes(this PropertyInfo prop)
        {
            var attributes = prop.GetCustomAttributes(typeof(BaseValidateAttribute));
            return attributes.Cast<BaseValidateAttribute>();
        }
    }
}
