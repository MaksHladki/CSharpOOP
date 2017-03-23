using System.Text.RegularExpressions;
using Validator.Core.ModelResult;

namespace Validator.Core.Attribute.Validation
{
    public class EmailValidateAttribute : BaseValidateAttribute
    {
        private const string Expression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public override IPropertyError Validate(object propValue)
        {
            var validationError = BuildErrorMessage(propValue);

            if (propValue == null) return validationError;

            var strValue = propValue as string;
            if (string.IsNullOrEmpty(strValue)) return validationError;

            return Regex.IsMatch(strValue, Expression) ? null : validationError;
        }
    }
}
